#include "program1.h"

#include <stdio.h>

#define KB 10

void program1(unsigned int virtual_address, unsigned int page_size)
{
	printf("The address %d contains:\n", virtual_address);
	printf("Page number = %d\n",
		virtual_address >> (KB + 2) // Bitshift right 10 (KB) times (divide by 2^KB) then bitshift right twice (divide by 4)
	);

	printf("Offset = %d\n",
		virtual_address & (page_size - 1) // Efficient remainder calculation for divisions by powers of 2. Effectively = address % page_size.
	);
}