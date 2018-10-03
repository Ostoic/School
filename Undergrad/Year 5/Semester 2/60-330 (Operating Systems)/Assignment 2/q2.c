#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <signal.h>
#include <sys/types.h>

#define TRUE 1
#define FALSE 0

#define BOOL int

#define THROW(message) fprintf(stderr, "Error: %s", message); return 0;

// Process information struct.
struct process
{
	pid_t pid;
	pid_t ppid;
	BOOL isZombie;
};

// Get path to the zombie factory.
// Output: Stores the path into the out variable.
BOOL getZombieFactoryPath(char* out, int max)
{
	char cwd[256];
	if (getcwd(cwd, 256) == NULL)
		return FALSE;
	
	if (snprintf(out, max, "%s/%s", cwd, "q1") == -1)
		return FALSE;
	
	return TRUE;
}

// Create zombie process by executing the program in question 1.
pid_t createZombie(const char* path)
{
	pid_t pid = fork();
	if (pid == -1)
		return -1;
	
	if (pid == 0)
	{
		execlp(path, path, (char*)NULL);
		printf("Done.\n");
		return 0;
	}

	return pid;
}

// Test if the given string is an integer.
BOOL isInteger(const char* string)
{
	const int len = strlen(string);
	
	for (int i = 0; i < len; ++i)
	{
		if (!isdigit(string[i]))
			return FALSE;
	}

	return TRUE;
}

// Parse the given string for process information.
// Output: Stores the process information into the out parameter if successful.
// Returns: 
//	true if successful,
//	false if any errors occured.
BOOL parseProcessInformation(const char* line, struct process* out)
{
	if (out == NULL)
		return FALSE;
	
	char buffState[64], buffPid[64], buffPPid[64];

	// Parse the given string into state, pid, and ppid buffers.
	if (sscanf(line, "%*s %s %*s %s %s", buffState, buffPid, buffPPid) == EOF)
		return FALSE;
	
	// If pid or ppid are not numbers, return false.
	if (!isInteger(buffPid) || !isInteger(buffPPid))
		return FALSE;

	// Convert pid and ppid buffers to integers.
	out->pid = atoi(buffPid);
	out->ppid = atoi(buffPPid);
	
	// Convert process state buffer to boolean value.
	if (buffState[0] == 'Z')
		out->isZombie = TRUE;
	else
		out->isZombie = FALSE;

	return TRUE;
}

// Retrieve the process list 
int getProcessList(struct process list[], unsigned int maxList)
{
	// Error
	if (list == NULL)
		return -1;

	const int maxBuffer = 256;
	char buffer[maxBuffer];

	unsigned int count = 0;

	// Open pipe to bash with the given ps command.
	FILE* pipe = popen("ps -l", "r");
	if (pipe == NULL)
		return -1;

	// Read data from the pipe's stdout until there is none left.
	while (fgets(buffer, maxBuffer, pipe) != NULL && count < maxList)
	{
		//printf("%s\n", buffer);
		if (parseProcessInformation(buffer, &list[count]))
			count++;
	}
	
	// Close the pipe.
	pclose(pipe);	
	return count;
}

// Print the given process' pid, parent pid, and whether or not it's a zombie.
// Prints in the format: {pid, ppid, isZombie}.
void printProcess(struct process* proc)
{		
	if (proc == NULL) 
		return;

	printf("Process {pid: %d, ppid: %d, isZombie: %s}\n", 
		proc->pid, proc->ppid, (proc->isZombie)?"true" : "false");
}

// Print process information for each process in the given list.
void printProcessList(struct process list[], unsigned int size)
{
	for (int i = 0; i < size; ++i)
		printProcess(&list[i]);
}

int main(int argc, char* argv[])
{
	if (argc != 2)
	{
		fprintf(stderr, "Usage: q2 <number of zombies>\n");
		return 0;
	}
	
	if (!isInteger(argv[1]))
	{
		fprintf(stderr, "Usage: q2 <number of zombies>\n");
		return 0;
	}
		
	// The number of zombie processes to create.
	const unsigned int numZombies = atoi(argv[1]);

	// Maximum number of processes in the process list.
	const unsigned int maxProc = 50;

	// Create the process list.
	struct process processList[maxProc];

	char path[256];

	// The path to the zombie factory program from question 1.
	// This is just "cwd/q1"
	if (!getZombieFactoryPath(path, 256))
	{
		perror("Unable to get zombie factory path: ");
		return -1;
	}
		
	
	// Part (a): Create zombie processes that each last for at least 10 seconds.
	for (int i = 0; i < numZombies; ++i)
	{
		if (createZombie(path) == -1)
		{
			perror("Unable to create zombie: ");
			return -1;
		}
	}

	// Part (b): Populate the process list.	
	// This give information about process state, pid, and ppid.
	unsigned int processCount = getProcessList(processList, maxProc);
	if (processCount == -1)
	{
		perror("Unable to get process list: ");
		return -1;
	}
	
	printf("Process count = %d\n", processCount);

	// Part (c): Display each process' pid, ppid, and isZombie state
	printProcessList(processList, processCount);
	
	unsigned int foundZombies = 0;
	
	// Kill the parents of any zombie process.
	for (unsigned int i = 0; i < processCount; ++i)
	{	
		if (processList[i].isZombie == TRUE)
		{	
			foundZombies++;
			// Kill the parent of any zombie process.
			printf("Removing zombie: ");
			printProcess(&processList[i]);
			kill(processList[i].ppid, SIGKILL);
		}	
	}
	
	printf("We found %d zombies\n", foundZombies);

	// Repopulate the process list after killing all the zombies above.
	processCount = getProcessList(processList, maxProc);
	if (processCount == -1)
	{
		perror("Unable to obtain process list: ");
		return 0;
	}
	
	printf("Process count = %d\n", processCount);

	// Print the process list.
	// Note: The zombies that appear on this list are there because this program created them,
	// and has yet to exit.
	printProcessList(processList, processCount);
	return 0;
}