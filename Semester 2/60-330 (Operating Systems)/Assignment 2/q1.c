#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>

int main(int argc, char* argv[])
{
	// Fork process into parent-child.
	pid_t pid = fork();

	if (pid == -1)
	{
		perror("Unable to create fork: ");
		return -1;
	}

	// Terminate the child immediately.
	if (pid == 0)
	{
		exit(0);
	}
	else
	{
		// Let the parent wait for at least 10 seconds.
		sleep(10);
	}
	
	return 0;
}