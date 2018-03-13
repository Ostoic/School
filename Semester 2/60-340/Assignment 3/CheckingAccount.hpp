#pragma once

#include "BankAccount.hpp"

class CheckingAccount : public BankAccount
{
public:
	CheckingAccount(double balance, double annualInterestRate);

	void withdraw(double amount) override;

	void monthlyProc() override;
};
