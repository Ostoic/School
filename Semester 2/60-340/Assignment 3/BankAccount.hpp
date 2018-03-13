#pragma once

class BankAccount
{
public:

	BankAccount(double balance, double annualInterestRate);

	virtual void deposit(double amount);
	virtual void withdraw(double amount);

	double balance() const;
	double initialBalance() const;

	int depositCount() const;
	int withdrawalCount() const;

	double serviceCharges() const;

	// Consider hiding these to prevent users messing with the internal state?
	virtual void calcInt();
	virtual void monthlyProc();

	virtual ~BankAccount() = default;

protected:
	double currentBalance_;
	const double initialBalance_;
	double annualInterestRate_;
	double monthlyServiceCharges_;

	int depositCount_;
	int withdrawalCount_;
};
