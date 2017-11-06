/**
 * Represents a bank account that has a balance you can withdraw and deposit from/to
 * This is the first version of the class BankAccount (without monthly charging)
 */
public class BankAccount
{
    private double balance;
    private double fee;

    /**
     * Default constructor with:
     * balance = 0 dollars
     * fee = 1 dollar
     */
    public BankAccount()
    {
        this.balance = 0;
        this.fee = 1; //
    }

    /**
     * Constructor with initialBalance as a parameter
     * fee = 1 dollar
     */
    public BankAccount(double initialBalance)
    {
        this.balance = initialBalance;
        this.fee = 1;
    }

    /**
     * Changes the required fee to pay for further transactions
     * @param fee the required fee to pay
     */
    public void setFee(double fee)
    {
        this.fee = fee;
    }

    /**
     * Impose the fee upon the current bank account
     * Subtract the current balance by the current fee
     */
    private void imposeFee()
    {
        this.balance -= this.fee;
    }

    /**
     * Deposits money into the bank account
     * @param amount the amount to deposit
     */
    public void deposit(double amount)
    {
        this.balance += amount;
        imposeFee();
    }

    /**
     * Withdraws from the bank account
     * @param amount amount to withdraw
     */
    public void withdraw(double amount)
    {
        this.balance -= amount;
        imposeFee();
    }

    /**
     * Gets the current balance of the  bank account
     * @return the current balance
     */
    public double getBalance()
    {
        return this.balance;
    }

}
