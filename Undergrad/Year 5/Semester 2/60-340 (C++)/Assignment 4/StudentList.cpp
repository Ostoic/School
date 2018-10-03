#include "StudentList.h"

#include <random>
#include <numeric>
#include "SRand.h"

std::ostream& operator<<(std::ostream& stream, const StudentList& students)
{
	return stream;
}

void StudentList::GenerateRandomIDs(std::vector<int>& ids, const int number_of_ids)
{
	// Generate a new random seed upon program start.
	static SRand seed{};

	ids.resize(number_of_ids);

	// Fill ids with consecutive numbers starting at 0 and ending at number_of_ids-1.
	std::iota(ids.begin(), ids.end(), 0);

	// Shuffle the vector to randomize the ids.
	std::random_shuffle(ids.begin(), ids.end());
}
