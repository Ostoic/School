// ostoic_BinaryTrees.cpp : Defines the entry point for the console application.

#include "binary_tree.h"
#include "employee_info.h"

#include <string>
#include <cctype>

using command = void(*)(binary_tree<employee_info>&);

void reset_cin()
{
	std::cin.clear();
	std::cin.ignore(std::numeric_limits<std::size_t>::max(), '\n');
}

void display_menu()
{
	std::cout <<
		"\n******** Binary Trees MENU ********\n\n"
		"1.  Insert one or more items\n"
		"2.  Delete one or more elements\n"
		"3.  Display the nodes of the tree\n"
		"4.  Get the number of nodes in the tree\n"
		"5.  Get the height of the tree\n"
		"6.  Get the width of the tree\n"
		"7.  Get the number of leaves of the tree\n"
		"8.  Find an employee in the employee tree\n"
		"9.  Exit\n\n";
}

int get_menu_choice(int min_choice, int max_choice)
{
	int choice = 0;

	const auto bad_input_for = [min_choice, max_choice](int& choice)
	{
		return (!(std::cin >> choice)) || (choice < min_choice || choice > max_choice);
	};

	std::cout << "Your choice, please (" << min_choice << " - " << max_choice << "): ";
	while (bad_input_for(choice))
	{
		reset_cin();
		std::cout << "Enter a number from " << min_choice << " through " << max_choice << " please: ";
	}

	return choice;
}

void display_submenu()
{
	std::cout <<
		"\n******* Binary Trees Display modes Sub MENU *******\n\n"
		"1.  Via inorder traversal\n"
		"2.  Via preorder traversal\n"
		"3.  Via postorder traversal\n"
		"4.  Exit\n\n";
}

bool is_number(const std::string& text)
{
	return std::find_if(text.begin(), text.end(), [](char c)
	{
		return !std::isdigit(c);
	}) == text.end();
}

void insert_items(binary_tree<employee_info>& tree)
{
	std::string input = "";
	do
	{
		std::cout << "Inserting any number or text to the tree or 00 to exit: \n";
		std::cin >> input;

		// If it's a number, insert it as a key
		if (is_number(input))
			tree.insert({static_cast<unsigned int>(std::stoi(input)), ""});

		// Otherwise insert it as text.
		else
			tree.insert({0, input});

	} while (input != "00");
}

// This is used in the binary_tree search function to find an employee record given a key
bool equals_key_employee(int key, const employee_info& info)
{
	return key == info.id();
}

// This is used in the binary_tree search function to find an employee record given a key
bool less_than_key_employee(int key, const employee_info& info)
{
	return key < info.id();
}

void delete_items(binary_tree<employee_info>& tree)
{
	int choice;

	while (true)
	{
		std::cout << "Enter an employee number to delete or 0 to exit: ";
		std::cin >> choice;

		if (std::cin.good())
		{
			if (choice == 0) break;

			const auto* employee = tree.find(choice, equals_key_employee, less_than_key_employee);
			if (employee)
			{
				tree.erase(*employee);
				std::cout << "Deleted employee record\n";
			}
			else
				std::cout << "Employee not found!\n";
		}
		else
			reset_cin();
	}
}

void display_nodes(binary_tree<employee_info>& tree)
{
	command commands[3] = {
		// Command 1
		[](binary_tree<employee_info>& tree) 
			{ std::cout << "Now, here are the nodes via inorder traversal:\n"; tree.display_inorder(); },

		// Command 2
		[](binary_tree<employee_info>& tree) 
			{ std::cout << "Now, here are the nodes via preorder traversal:\n"; tree.display_preorder(); },

		// Command 3
		[](binary_tree<employee_info>& tree) 
			{ std::cout << "Now, here are the nodes via postorder traversal:\n"; tree.display_postorder(); },
	};

	while (true)
	{
		display_submenu();
		int choice = get_menu_choice(1, 4);
		if (choice == 4) break;
		commands[choice - 1](tree);
	}
}

void display_size(binary_tree<employee_info>& tree)
{
	std::cout << "Number of nodes: " << tree.size() << "\n\n";
}

void display_height(binary_tree<employee_info>& tree)
{
	std::cout << "Height: " << tree.height() << "\n\n";
}

void display_width(binary_tree<employee_info>& tree)
{
	std::cout << "Width: " << tree.width() << "\n\n";
}

void display_leaf_count(binary_tree<employee_info>& tree)
{
	std::cout << "Number of leaf nodes: " << tree.leaf_count() << "\n\n";
}

void find_employee(binary_tree<employee_info>& tree)
{
	int choice;

	while (true)
	{
		std::cout << "Enter an employee number to find or 0 to exit: ";
		std::cin >> choice;

		if (std::cin.good())
		{
			if (choice == 0) break;

			const auto* employee = tree.find(choice, equals_key_employee, less_than_key_employee);
			if (employee)
				std::cout << *employee << '\n';
			else
				std::cout << "Employee not found!\n";
		}
		else
			reset_cin();
	}
}

void exit_driver(binary_tree<employee_info>& tree)
{
	std::exit(0);
}

int main()
{
	command commands[9] = {
		insert_items,
		delete_items,
		display_nodes,
		display_size,
		display_height,
		display_width,
		display_leaf_count,
		find_employee,
		exit_driver
	};

	binary_tree<employee_info> employee_tree;
	employee_tree.insert({ 1021, "John Williams" });
	employee_tree.insert({ 1057, "Bill Witherspoon" });
	employee_tree.insert({ 2487, "Jennifer Twain" });
	employee_tree.insert({ 3769, "Sophie Lancaster" });
	employee_tree.insert({ 1017, "Debbie Reece" });
	employee_tree.insert({ 1275, "Georgie McMullen" });
	employee_tree.insert({ 1899, "Ashley Smith" });
	employee_tree.insert({ 4218, "Josh Plemmons" });

	while (true)
	{
		display_menu();
		int choice = get_menu_choice(1, 9);
		commands[choice - 1](employee_tree);
	}

	return 0;
}

