#include <iostream>
#include "StudentList.h"

#include <array>
#include <unordered_map>
#include <stack>
#include <queue>

class test
{
public:
	test(int) {}

private:
	int x;
	int y;
};

int main()
{
	std::vector<int> ids;

	StudentList::GenerateRandomIDs(ids, 10);
	for (auto id : ids)
		std::cout << id << ' ';
	std::cout << '\n';

//	StudentList student_list("names.csv");
//
//	std::cout << student_list << std::endl;
//
//	double duration_of_vector_sort = student_list.sort_vector();
//	double duration_of_list_sort = student_list.sort_list();
//
//	std::cout << student_list << std::endl;
//
//	std::cout << "The vector sort took " << duration_of_vector_sort << " seconds.\n";
//	std::cout << "The list sort took " << duration_of_list_sort << " seconds.\n";
//
//	std::cout << "Press any key to continue ... ";
//
//	char c;
//	std::cin.get(c);
//
//	double duration_of_vector_search = student_list.search_vector_by_id(750);
//	double duration_of_list_search = student_list.search_list_by_id(750);
//
//	//cout << "The vector search took " << duration_of_vector_search << " seconds.\n";
//	std::cout << "The list search took " << duration_of_list_search << " seconds.\n";
//
//	std::cout << "Press any key to exit ... ";
//	std::cin.get(c);
	return 0;
}