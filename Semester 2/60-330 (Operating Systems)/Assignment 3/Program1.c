// OS Assignment 3.cpp : Defines the entry point for the console application.

#include "Program1.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <Windows.h>

static unsigned int circle_count = 0;

static double random_double()
{
	return rand() / ((double)RAND_MAX + 1);
}

static void count_hits(unsigned int number_of_points)
{
	unsigned int hit_count = 0;

	for (int i = 0; i < number_of_points; ++i)
	{
		double x = random_double() * 2.0 - 1.0;
		double y = random_double() * 2.0 - 1.0;

		if (sqrt(x * x + y * y) < 1.0)
			++hit_count;
	}

	circle_count = hit_count;
}

double program1(unsigned int number_of_points)
{
	LARGE_INTEGER frequency;
	LARGE_INTEGER start;
	LARGE_INTEGER end;

	QueryPerformanceFrequency(&frequency);
	QueryPerformanceCounter(&start); // Start timing

	// Create circle hitting slave thread
	HANDLE thread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)count_hits, number_of_points, 0, NULL);
	if (thread == NULL)
	{
		fprintf(stderr, "Unable to create thread: %d", GetLastError());
		return 0;
	}

	// Wait for slave thread to finish.
	WaitForSingleObject(thread, INFINITE);
	QueryPerformanceCounter(&end); // Stop timing

	double pi = 4 * (circle_count) / (double)number_of_points;
	printf("Pi approx = %lf\n", pi);
	return (double)(end.QuadPart - start.QuadPart) / frequency.QuadPart;
}

