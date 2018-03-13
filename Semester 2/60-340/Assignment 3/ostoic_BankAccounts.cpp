// ostoic_BankAccounts.cpp : Defines the entry point for the console application.

#include "SavingsAccount.hpp"
#include <iostream>
#include <string>
#include <array>
#include "CheckingAccount.hpp"

enum class InputChoice
{
	SavingsDeposit = 1,
	CheckingDeposit = 2,
	SavingsWithdraw = 3,
	CheckingWithdraw = 4,
	UpdateDisplayStats = 5,
	Exit = 6
};

std::istream& operator>>(std::istream& stream, InputChoice& choice)
{
	int buffer;
	stream >> buffer;

	// If the buffer is not within the range of the InputChoice enum, set the stream's failbit.
	if (!(static_cast<int>(InputChoice::SavingsDeposit) <= buffer && buffer <= static_cast<int>(InputChoice::Exit)))
		stream.setstate(std::ios::failbit);
	else
		choice = static_cast<InputChoice>(buffer);
		
	return stream;
}

// Clear the fail bit and ignore all the invalid input up until the next line.
void resetCin()
{
	// Clear fail bit
	std::cin.clear();

	// Ignore the invalid input
	std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
}

// Poll the user until valid input is received.
// @param invalidInputMessage the error message to display given invalid input.
// @returns the input given by the user of type T.
template <typename T>
T pollInput(const std::string& invalidInputMessage)
{
	T input;

	// Invalid input poll
	while (true)
	{
		std::cin >> input;

		// Only continue if we've consumed a number all the way to the end of the line
		if (std::cin.peek() == '\n' && std::cin) break;

		resetCin();
		std::cout << invalidInputMessage;
	}

	return input;
}

void withdrawInput(BankAccount& account)
{
	std::cout << "Enter amount to withdraw: ";

	// Get the amount from the user
	const auto amount = pollInput<double>("Please enter a valid decimal number: ");

	// Withdraw the given amount
	account.withdraw(amount);
}

void depositInput(BankAccount& account)
{
	std::cout << "Enter amount to deposit: ";

	// Get the amount from the user
	const auto amount = pollInput<double>("Please enter a valid decimal number: ");

	// Deposit the given amount
	account.deposit(amount);
}

void displayStatistics(BankAccount& account)
{
	// Update monthly rates
	// Update the rates before display the stats?
	// It seems this is what the aassignment is asking for, although I'm not sure...
	account.monthlyProc();

	// Display stats
	std::cout
		<< "Withdrawals:\t\t" << account.withdrawalCount() << '\n'
		<< "Deposits:\t\t" << account.depositCount() << '\n'
		<< "Service Charges:\t" << account.serviceCharges() << "\n\n"

		<< "Initial Balance:\t" << account.initialBalance() << '\n'
		<< "Balance:\t\t" << account.balance() << '\n';

}

void displayStatistics(SavingsAccount& savings, CheckingAccount& checking)
{
	std::cout << "SAVINGS ACCOUNT MONTHLY STATISTICS:\n";
	displayStatistics(savings);

	std::cout << '\n'
		<< "CHECKING ACCOUNT MONTHLY STATISTICS:\n";
	displayStatistics(checking);
}


void displayMenu()
{
	std::cout
		<< "1.  Savings Account Deposit\n"
		<< "2.  Checking Account Deposit\n"
		<< "3.  Savings Account Withdrawal\n"
		<< "4.  Checking Account Withdrawal\n"
		<< "5.  Update and Display Account Statistics\n"
		<< "6.  Exit\n";
}

int main()
{
	SavingsAccount savings(15, 2);
	CheckingAccount checking(30, 2);

	bool sentinel = false;

	do
	{
		displayMenu();
		std::cout << "Your choice, please: (1-6) ";

		const auto choice = pollInput<InputChoice>("Invalid choice, please select a number from 1 to 6: ");
		std::cout << '\n';

		switch (choice)
		{
		case InputChoice::SavingsDeposit:
			depositInput(savings);
			break;

		case InputChoice::CheckingDeposit:
			depositInput(checking);
			break;

		case InputChoice::SavingsWithdraw:
			withdrawInput(savings);
			break;

		case InputChoice::CheckingWithdraw:
			withdrawInput(checking);
			break;

		case InputChoice::UpdateDisplayStats:
			displayStatistics(savings, checking);
			break;

		case InputChoice::Exit:
			sentinel = true;
			break;
		}

		std::cout << '\n';
	} while (!sentinel);

	return 0;
}

