#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <time.h>
#include <ctype.h>

#include "program1.h"
#include "program2.h"

#define KB 10

bool is_number(const char* string)
{
	for (int i = 0; string[i] != 0; ++i)
		if (!isdigit(string[i]))
			return false;

	return true;
}

int main(int argc, char* argv[])
{
	if (argc != 2)
	{
		fprintf(stderr, "Usage: %s [virtual address]\n", argv[0]);
		return 0;
	}

	if (!is_number(argv[1]))
	{
		fprintf(stderr, "Virtual address must be in decimal\n");
		return 0;
	}

	// Set the page size to be 4 kilobytes (2^(10 + 2))
	unsigned int page_size = (4 << KB);
	unsigned int address = atoi(argv[1]);

	// Seed the rng.
	srand(time(NULL));

	//program1(address, page_size);
	program2(1E6, page_size);
	return 0;
}