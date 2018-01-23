#include "stdafx.h"

#include <Windows.h>

void removeNewline(wchar_t* string)
{
	unsigned int len = lstrlenW(string);
	string[len - 1] = 0;
}

int wmain()
{
	wchar_t inputFile[MAX_PATH];
	wchar_t outputFile[MAX_PATH];

	// Ask user for input file.
	wprintf(L"Enter input file: ");
	fgetws(inputFile, sizeof(inputFile) / sizeof(wchar_t), stdin);

	// Ask user for output file.
	wprintf(L"Enter output file: ");
	fgetws(outputFile, sizeof(outputFile) / sizeof(wchar_t), stdin);

	// Remove any newline characters from the filenames.
	removeNewline(inputFile);
	removeNewline(outputFile);

	wprintf(L"Opening file %s for reading...", inputFile);
	// Open the file specified in the first command line argument with read access. If the file does not exist, an error message is displayed.
	// If any other error occurs, its error code is displayed after which the program will terminate.
	HANDLE readHandle = CreateFile(inputFile, GENERIC_READ, NULL, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	if (readHandle == INVALID_HANDLE_VALUE)
	{
		wprintf(L"\nUnable to open file %s for reading: ", inputFile);
		if (GetLastError() == ERROR_FILE_NOT_FOUND)
			wprintf(L"File does not exist.\n");
		else
			wprintf(L"GetLastError %d\n", GetLastError());

		return 0;
	}
	wprintf(L"Done.\n");

	wprintf(L"Creating file %s for writing...", outputFile);
	// Create a file with the given name with write access. If the file already exists, then an error message will be displayed.
	// If any other error occurs, its error code is displayed after which the program will terminate.
	HANDLE writeHandle = CreateFile(outputFile, GENERIC_WRITE, NULL, NULL, CREATE_NEW, FILE_ATTRIBUTE_NORMAL, NULL);
	if (writeHandle == INVALID_HANDLE_VALUE)
	{
		wprintf(L"\nUnable to create file %s for writing: ", outputFile);
		if (GetLastError() == ERROR_FILE_EXISTS)
			wprintf(L"File already exists.\n");
		else
			wprintf(L"GetLastError %d\n", GetLastError());

		CloseHandle(readHandle);
		return 0;
	}
	wprintf(L"Done.\n");

	// File read buffer
	wchar_t buffer[256];
	DWORD bytesRead = 0; // Number of bytes read from the file

	wprintf(L"Copying %s to %s...", inputFile, outputFile);
	// Read the file until failure, or until there are no more bytes left to read.
	while (ReadFile(readHandle, buffer, sizeof(buffer), &bytesRead, NULL) && bytesRead > 0)
	{
		DWORD bytesWritten = 0;

		// Write the current buffer to the output file.
		if (!WriteFile(writeHandle, buffer, bytesRead, &bytesWritten, NULL))
		{
			wprintf(L"\nError writing to file: %d\n", GetLastError());
			break;
		}
	}
	
	wprintf(L"Done.\n");
	wprintf(L"Finished.\n");
	CloseHandle(readHandle);
	CloseHandle(writeHandle);
	return 0;
}