#pragma once

#include "Student.h"

#include <vector>
#include <list>

class StudentList
{
public:
	StudentList(const std::string& filename);

	/// @return time in milliseconds it took to sort the vector.
	double sort_vector();

	/// @return time in milliseconds it took to sort the list.
	double sort_list();
	
	double search_list_by_id(int);
	double search_vector_by_id(int);

	static void GenerateRandomIDs(std::vector<int>& ids, int number_of_ids);

	friend std::ostream& operator<<(std::ostream& stream, const StudentList& students);
private:
	std::vector<Student> student_vector_;
	std::list<Student> student_list_;
};
