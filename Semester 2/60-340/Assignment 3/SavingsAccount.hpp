#pragma once

#include "BankAccount.hpp"

class SavingsAccount : public BankAccount
{
public:
	SavingsAccount(double balance, double annualInterestRate);

	bool active() const;

	void deposit(double amount) override;
	void withdraw(double amount) override;

	void monthlyProc() override;

private:
	// Determine if the account is inactive or not
	bool checkInactive() const;

private:
	bool active_;

	static constexpr int inactiveBalanceThreshold = 25;
};

