// OS Assignment 3.cpp : Defines the entry point for the console application.

#include "Program3.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <Windows.h>

#define NUMBER_OF_SLAVES 40

static HANDLE mutex;

static unsigned int circle_count = 0;

static double random_double()
{
	return rand() / ((double)RAND_MAX + 1);
}

// Each thread is given a number of points to generate and test for hitting.
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

	// Request ownership of mutex.
	DWORD wait = WaitForSingleObject(mutex, INFINITE);
	
	// If we've obtained ownership, then continue.
	if (wait == WAIT_OBJECT_0)
	{
		circle_count += hit_count;

		// Release the mutex.
		ReleaseMutex(mutex);
	}
}

double program3(unsigned int number_of_points)
{
	HANDLE threads[NUMBER_OF_SLAVES];
	LARGE_INTEGER frequency;
	LARGE_INTEGER start;
	LARGE_INTEGER end;

	QueryPerformanceFrequency(&frequency);
	QueryPerformanceCounter(&start); // Start timing

	// Create mutex for the global circle_count variable.
	mutex = CreateMutex(NULL, FALSE, NULL);
	if (mutex == NULL)
	{
		fprintf(stderr, "Unable to create mutex: %d", GetLastError());
		return 0;
	}

	// Create circle hit slave threads.
	for (int i = 0; i < NUMBER_OF_SLAVES; ++i)
	{
		threads[i] = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)count_hits, number_of_points / NUMBER_OF_SLAVES, 0, NULL);
		if (threads[i] == NULL)
		{
			fprintf(stderr, "Unable to create thread: %d", GetLastError());
			return 0;
		}
	}

	// Wait for all the threads to join.
	DWORD wait = WaitForMultipleObjects(NUMBER_OF_SLAVES, threads, TRUE, INFINITE);

	// Close all of the thread handles.
	for (int i = 0; i < NUMBER_OF_SLAVES; ++i)
		CloseHandle(threads[i]);
	
	CloseHandle(mutex);
	QueryPerformanceCounter(&end); // Stop timing

	double pi = 4 * (circle_count) / (double)number_of_points;
	printf("Pi approx = %lf\n", pi);
	return (double)(end.QuadPart - start.QuadPart) / frequency.QuadPart;
}

