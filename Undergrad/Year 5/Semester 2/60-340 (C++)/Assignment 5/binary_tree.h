#ifndef BINARYTREE_H
#define BINARYTREE_H

#include <iostream>
#include <vector>
#include <algorithm>

template <typename T>
class binary_tree
{
public:
	binary_tree() 
		: root_(nullptr) 
	{}

	~binary_tree()
	{
		this->traverse_postorder(this->root_, [](Node* node)
		{
			delete node;
		});
	}

	/// @brief Output the contents of the tree via preorder traversal.
	void display_preorder()	const;

	/// @brief Output the contents of the tree via inorder traversal.
	void display_inorder()	const;

	/// @brief Output the contents of the tree via postorder traversal.
	void display_postorder() const;

	/// @brief Test if the tree contains the given value in one of its node.
	/// @param value the value to search for.
	/// @return true if the value was found in the tree, and false otherwise.
	bool contains(const T& value) const;

	/// @brief Count the number of leaves in the tree.
	unsigned int leaf_count() const;

	/// @brief Get the number of nodes in the tree.
	unsigned int size() const;

	/// @brief Calculate the maximum depth in the tree.
	unsigned int height() const;

	/// @brief Calculate the maximum width of nodes in the tree.
	unsigned int width() const;

	/// @brief Insert a new value into the binary search tree as a node. Preserves the integrity of the search tree.
	/// @param value the value to insert into a node.
	void insert(const T& value);

	/// @brief Unlink and destroy a node whose \a value is found in the tree. If \a value is not found, nothing is done.
	/// @param value the value to search for.
	void erase(const T& value);

	/// @brief Find an instance of the value in the tree given a key.
	/// @param key the key to use in the search.
	/// @return a pointer to the value, and nullptr if the key wasn't found.
	template <typename Key, typename Equals, typename LessThan>
	const T* find(Key key, Equals equals, LessThan less_than) const;

private:
	/// @brief Implementation struct representing a node in the tree.
	struct Node
	{
		T value;
		Node* left;
		Node* right;
	};
	
	/// @brief Test if a given node is a leaf node.
	/// @param node the node to test.
	/// @return true if the node is a leaf, and false otherwise.
	static bool is_leaf(const Node* node);

	/// @brief Prints the value of a node.
	/// @param node the node to print.
	static void print_node(const Node* node);

	/// @brief Insert a given node as a leaf in the tree.
	/// @param node the node used to traverse down the tree.
	/// @param new_node the node to insert.
	void insert_new_leaf(Node*& node, Node* new_node);

	void find_node_to_delete(Node*& root, const T& value);

	void delete_node(Node*& root);

	/// @brief Generic preorder traversal that applies a given function taking a node as an argument at each step.
	/// @param node the starting node traverse down.
	/// @param visit the function to apply to each node.
	template <typename Func>
	void traverse_preorder(Node* node, Func visit) const;

	/// @brief Generic inorder traversal that applies a given function taking a node as an argument at each step.
	/// @param node the starting node traverse down.
	/// @param visit the function to apply to each node.
	template <typename Func>
	void traverse_inorder(Node* node, Func visit) const;

	/// @brief Generic postorder traversal that applies a given function taking a node as an argument at each step.
	/// @param node the starting node traverse down.
	/// @param visit the function to apply to each node.
	template <typename Func>
	void traverse_postorder(Node* node, Func visit) const;

	/// @brief Generic preorder level traversal that applies a given function taking a node as an argument at each step.
	/// @param node the starting node traverse down.
	/// @param level the current level (depth) in the tree.
	/// @param visit the function to apply to each node.
	template <typename Func>
	void traverse_levelorder(Node* node, Func visit, unsigned int level = 1) const;

	/// @brief Search for a node in the tree containing the given value.
	/// @param value the value of the node to search for.
	Node* find_node(Node* node, const T& value) const;

	Node* root_;
};

/********************************
 * public interface functions
 ********************************/
template <typename T>
void binary_tree<T>::display_preorder() const
{
	this->traverse_preorder(this->root_, print_node);
}

template <typename T>
void binary_tree<T>::display_inorder() const
{
	this->traverse_inorder(this->root_, print_node);
}

template <typename T>
void binary_tree<T>::display_postorder() const
{
	this->traverse_postorder(this->root_, print_node);
}

template <typename T>
unsigned int binary_tree<T>::leaf_count() const
{
	unsigned int count = 0;
	this->traverse_postorder(this->root_, [&count](const Node* node)
	{
		if (binary_tree::is_leaf(node))
			count++;
	});

	return count;
}

template <typename T>
unsigned int binary_tree<T>::size() const
{
	unsigned int count = 0;
	this->traverse_postorder(this->root_, [&count](const Node* node)
	{
		count++;
	});

	return count;
}

template <typename T>
unsigned int binary_tree<T>::height() const
{
	unsigned int height = 1;

	// Find the maximum depth of the tree.
	this->traverse_levelorder(this->root_, [&height](const Node* node, unsigned int current_level)
	{
		if (current_level > height)
			height = current_level;
	});

	return height;
}

template <typename T>
unsigned int binary_tree<T>::width() const
{
	// Initialize the vector of level node counts to have size this->height() whose elements are intialized to 0.
	std::vector<unsigned int> levels_count(this->height());

	// Count the number of nodes on each level of the tree
	this->traverse_levelorder(this->root_, [&levels_count](const Node* node, unsigned int current_level)
	{
		levels_count[current_level - 1]++;
	});

	// Return the max of all such numbers
	return *std::max_element(levels_count.begin(), levels_count.end());
}

template <typename T>
void binary_tree<T>::insert(const T& value)
{
	// Create a new leaf node.
	Node* node_node = new Node {value, nullptr, nullptr};

	// Insert it into the tree.
	this->insert_new_leaf(this->root_, node_node);
}

template <typename T>
void binary_tree<T>::erase(const T& value)
{
	this->find_node_to_delete(this->root_, value);
}

template <typename T>
template <typename Key, typename Equals, typename LessThan>
const T* binary_tree<T>::find(Key key, Equals equals, LessThan less_than) const
{
	Node* node = this->root_;
	while (node != nullptr)
	{
		if (equals(key, node->value))
			return &node->value;

		else if (less_than(key, node->value))
			node = node->left;

		else
			node = node->right;
	}

	return nullptr;
}

template <typename T>
bool binary_tree<T>::contains(const T& value) const
{
	return this->find_node(this->root_, value);
}

/************************************
 * static private implementation functions
 ***********************************/
template <typename T>
bool binary_tree<T>::is_leaf(const Node* node)
{
	return node->left == nullptr && node->right == nullptr;
}

template <typename T>
void binary_tree<T>::print_node(const Node* node)
{
	// Precondition: node points to a valid Node.
	std::cout << node->value << '\n';
}

/************************************
* private implementation functions
***********************************/
template <typename T>
void binary_tree<T>::insert_new_leaf(Node*& node, Node* new_node)
{
	if (node == nullptr)
		node = new_node;

	else if (new_node->value < node->value)
		this->insert_new_leaf(node->left, new_node);
	else
		this->insert_new_leaf(node->right, new_node);
}

template <typename T>
void binary_tree<T>::find_node_to_delete(Node*& root, const T& value)
{
	if (value < root->value)
		find_node_to_delete(root->left, value);

	else if (value > root->value)
		find_node_to_delete(root->right, value);

	else
		this->delete_node(root);
}

template <typename T>
void binary_tree<T>::delete_node(Node*& root)
{
	if (root == nullptr)
		return;

	// Reattach the left child to the rest of the tree above
	if (root->right == nullptr)
	{
		Node* to_delete = root;
		root = root->left;
		delete to_delete;
	}
	
	// Reattach the right child to the rest of the tree above
	else if (root->left == nullptr)
	{
		Node* to_delete = root;
		root = root->right;
		delete to_delete;
	}

	// Node has two children, in which case we need to 
	else
	{
		// Move one to the right.
		Node* temp = root->right;

		// Then go to the end of the left subtree.
		while (temp->left != nullptr)
			temp = temp->left;

		// Take lowest node and place it where the root is.
		temp->left = root->left;
		temp = root;

		root = root->right;

		// Discard the removed node.
		delete temp;
	}
}


template <typename T>
template <typename Func>
void binary_tree<T>::traverse_preorder(Node* node, Func visit) const
{
	if (node == nullptr) return;

	visit(node);
	traverse_preorder(node->left, visit);
	traverse_preorder(node->right, visit);
}

template <typename T>
template <typename Func>
void binary_tree<T>::traverse_inorder(Node* node, Func visit) const
{
	if (node == nullptr) return;

	traverse_inorder(node->left, visit);
	visit(node);
	traverse_inorder(node->right, visit);
}

template <typename T>
template <typename Func>
void binary_tree<T>::traverse_postorder(Node* node, Func visit) const
{ 
	if (node == nullptr) return;

	traverse_postorder(node->left, visit);
	traverse_postorder(node->right, visit);
	visit(node);
}

template <typename T>
template <typename Func>
void binary_tree<T>::traverse_levelorder(Node* node, Func visit, unsigned int level) const
{
	if (node == nullptr) return;

	visit(node, level);
	traverse_levelorder(node->left, visit, level + 1);
	traverse_levelorder(node->right, visit, level + 1);
}

template <typename T>
typename binary_tree<T>::Node* binary_tree<T>::find_node(Node* node, const T& value) const
{
	while (node != nullptr)
	{
		if (value == node->value)
			return node;

		else if (value < node->value)
			node = node->left;

		else
			node = node->right;
	}

	return nullptr;
}


#endif