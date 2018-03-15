#include "program2.h"

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include <stdlib.h>

#define KB 10

// Generate n random virtual addresses, then calculate the page number and offset using standard division and remainder operators.
void normal_method(int number_of_addresses, unsigned int page_size)
{
	for (int i = 0; i < number_of_addresses; ++i)
	{
		// Generate number larger than RAND_MAX, which is typically 2^16
		unsigned int address =
			((rand() << 0) & 0x0000FFFF) | // Shift random number into the [2^0, 2^16) range
			((rand() << 16) & 0xFFFF0000); // Shift random number into the [2^16, 2^32) range
		volatile unsigned int page_number = (address / page_size);
		volatile unsigned int offset = address % page_size;
	}
}

// Generate n random virtual addresses, then calculate the page number and offset using bitshift and bitwise AND.
void bits_method(int number_of_addresses, unsigned int page_size)
{
	for (int i = 0; i < number_of_addresses; ++i)
	{
		// Generate number larger than RAND_MAX, which is typically 2^16
		unsigned int address =
			((rand() << 0) & 0x0000FFFF) | // Shift random number into the [2^0, 2^16) range
			((rand() << 16) & 0xFFFF0000); // Shift random number into the [2^16, 2^32) range

		// Bitshift right 10 (KB) times (divide by 2^KB) then bitshift right twice (divide by 4)
		unsigned int page_number = address >> (KB + 2);

		// Efficient remainder calculation for divisions by powers of 2. Effectively = address % page_size.
		unsigned int offset = address & (page_size - 1);
	}
}

void program2(int number_of_addresses, unsigned int page_size)
{
	LARGE_INTEGER frequency;
	LARGE_INTEGER start;
	LARGE_INTEGER end;

	printf("Generating %d random virtual addresses, then calculating page number and offset given a page size of %d bytes\n", number_of_addresses, page_size);

	QueryPerformanceFrequency(&frequency);
	QueryPerformanceCounter(&start); // Start timing
	normal_method(number_of_addresses, page_size);
	QueryPerformanceCounter(&end); // Stop timing
	printf("Using normal division and remainder: %fs\n", (double)(end.QuadPart - start.QuadPart) / frequency.QuadPart);

	QueryPerformanceFrequency(&frequency);
	QueryPerformanceCounter(&start); // Start timing
	bits_method(number_of_addresses, page_size);
	QueryPerformanceCounter(&end); // Stop timing
	printf("Using bitshift and bitmask: %fs\n", (double)(end.QuadPart - start.QuadPart) / frequency.QuadPart);
}

