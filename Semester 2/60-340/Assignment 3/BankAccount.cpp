#include "BankAccount.hpp"

BankAccount::BankAccount(const double balance, const double annualInterestRate)
	: currentBalance_(balance), initialBalance_(balance)
	, annualInterestRate_(annualInterestRate)
	, monthlyServiceCharges_(0)
	, depositCount_(0), withdrawalCount_(0)
{}

void BankAccount::deposit(const double amount)
{
	this->currentBalance_ += amount;
	this->depositCount_++;
}

void BankAccount::withdraw(const double amount)
{
	this->currentBalance_ -= amount;
	this->withdrawalCount_++;
}

double BankAccount::balance() const
{
	return this->currentBalance_;
}

double BankAccount::initialBalance() const
{
	return this->initialBalance_;
}

int BankAccount::depositCount() const
{
	return this->depositCount_;
}

int BankAccount::withdrawalCount() const
{
	return this->withdrawalCount_;
}

double BankAccount::serviceCharges() const
{
	return this->monthlyServiceCharges_;
}


void BankAccount::calcInt()
{
	const double monthlyInterestRate = this->annualInterestRate_ / 2;
	const double monthlyInterest = this->currentBalance_ * monthlyInterestRate;
	this->currentBalance_ += monthlyInterest;
}

void BankAccount::monthlyProc()
{
	// Subtract monthly service from the balance
	this->currentBalance_ -= this->monthlyServiceCharges_;

	// Add last month's interest to the balance
	this->calcInt();

	// Reset the deposit and withdrawl counts
	this->depositCount_ = 0;
	this->withdrawalCount_ = 0;
}