#include "CheckingAccount.hpp"
#include <iostream>


CheckingAccount::CheckingAccount(const double balance, const double annualInterestRate)
	: BankAccount(balance, annualInterestRate) 
{}

void CheckingAccount::withdraw(const double amount)
{
	constexpr double serviceCharge = 15;
	if (this->balance() - amount < 0)
		this->currentBalance_ -= serviceCharge;

	BankAccount::withdraw(amount);
}

void CheckingAccount::monthlyProc()
{
	constexpr double monthlyFee = 5.0;
	this->monthlyServiceCharges_ += monthlyFee + 0.10 * this->withdrawalCount();
	BankAccount::monthlyProc();
}