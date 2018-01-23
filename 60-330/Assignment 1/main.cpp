#include "stdafx.h"

#include <Windows.h>

int wmain(int argc, wchar_t* argv[])
{
	if (argc != 3)
	{
		wprintf(L"Usage: copy <input file> <output file>\n");
		return 0;
	}

	wprintf(L"Copying %s to %s...", argv[1], argv[2]);

	// Open the file specified in the first command line argument with read access. If the file does not exist, an error message is displayed.
	// If any other error occurs, its error code is displayed after which the program will terminate.
	HANDLE readHandle = CreateFile(argv[1], GENERIC_READ, NULL, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	if (readHandle == INVALID_HANDLE_VALUE)
	{
		wprintf(L"\nUnable to open file %s for reading: ", argv[1]);
		if (GetLastError() == ERROR_FILE_NOT_FOUND)
			wprintf(L"File does not exist.\n");
		else
			wprintf(L"GetLastError %d", GetLastError());

		return 0;
	}

	// Create a file with the given name with write access. If the file already exists, then an error message will be displayed.
	// If any other error occurs, its error code is displayed after which the program will terminate.
	HANDLE writeHandle = CreateFile(argv[2], GENERIC_WRITE, NULL, NULL, CREATE_NEW, FILE_ATTRIBUTE_NORMAL, NULL);
	if (writeHandle == INVALID_HANDLE_VALUE)
	{
		wprintf(L"\nUnable to create file %s for writing: ", argv[2]);
		if (GetLastError() == ERROR_FILE_EXISTS)
			wprintf(L"File already exists.\n");
		else
			wprintf(L"GetLastError %d", GetLastError());

		CloseHandle(readHandle);
		return 0;
	}

	// File buffer
	char buffer[256];
	DWORD bytesRead = 0; // Number of bytes read from the file

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
	CloseHandle(readHandle);
	CloseHandle(writeHandle);
    return 0;
}