// OS Assignment 3.cpp : Defines the entry point for the console application.

#include "Program4.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <Windows.h>

#define NUMBER_OF_SLAVES 40

static unsigned int circle_count = 0;

static double random_double()
{
	return rand() / ((double)RAND_MAX + 1);
}

static void count_hits(unsigned int number_of_points)
{
	unsigned int hit_count = 0;
	int i;
#pragma omp parallel for num_threads(NUMBER_OF_SLAVES) 
	for (i = 0; i < number_of_points; ++i)
	{
		double x = random_double() * 2.0 - 1.0;
		double y = random_double() * 2.0 - 1.0;

		if (sqrt(x * x + y * y) < 1.0)
#pragma omp atomic
			++hit_count;
	}

	circle_count = hit_count;
}

double program4(unsigned int number_of_points)
{
	LARGE_INTEGER frequency;
	LARGE_INTEGER start;
	LARGE_INTEGER end;

	QueryPerformanceFrequency(&frequency);
	QueryPerformanceCounter(&start); // Start timing
	count_hits(number_of_points);
	QueryPerformanceCounter(&end); // Stop timing

	double pi = 4 * ((double)circle_count) / (double)number_of_points;
	printf("Pi approx = %lf\n", pi);
	circle_count = 0;
	return (double)(end.QuadPart - start.QuadPart) / frequency.QuadPart;
}

