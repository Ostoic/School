#include "SavingsAccount.hpp"
#include <iostream>

SavingsAccount::SavingsAccount(const double balance, const double annualInterestRate)
	: BankAccount(balance, annualInterestRate)
	, active_(this->balance() >= SavingsAccount::inactiveBalanceThreshold)
{}

bool SavingsAccount::active() const
{
	return this->active_;
}

void SavingsAccount::deposit(const double amount)
{
	if (!this->active() && this->balance() + amount >= SavingsAccount::inactiveBalanceThreshold)
		this->active_ = true;

	std::cout << "savings deposit\n";
	BankAccount::deposit(amount);
}

void SavingsAccount::withdraw(const double amount)
{
	// If the account is active, we can withdraw money from it.
	if (this->active())
	{
		BankAccount::withdraw(amount);

		// If the withdrawal put the account's balance below $25, the account is now inactive.
		if (this->checkInactive())
			this->active_ = false;
	}
}

void SavingsAccount::monthlyProc()
{
	constexpr int withdrawalThreshold = 4;

	const int withdrawalDifference = this->withdrawalCount() - withdrawalThreshold;

	// withdrawalCount > threshold => $1 service charge for each withdrawal about the threshold
	if (withdrawalDifference > 0)
	{
		this->monthlyServiceCharges_ += withdrawalDifference;

		// If the withdrawal put the account's balance below $25, the account is now inactive.
		if (this->checkInactive())
			this->active_ = false;
	}

	// If the withdrawal put the account's balance below $25, the account is now inactive.
	BankAccount::monthlyProc();
}

bool SavingsAccount::checkInactive() const
{
	return this->balance() < SavingsAccount::inactiveBalanceThreshold;
}
