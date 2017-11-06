// Unit test for the first version of BankAccount from problem 3
public class BankAccount1Test
{
    public static void main(String[] args)
    {
		// Create new bank account starting with an initial balance of $1000.
		BankAccount1 account = new BankAccount1(1000);
        account.setFee(2);
        account.deposit(200); // 1 fee charged
        account.withdraw(10); // 2 fees charged

        System.out.println("Current balance = " + account.getBalance());
		
        // Each transaction fee is 2 and there have been 2 transactions.
		// 1000 initial balance, 200 deposited, and 10 withdrawn.
        System.out.println("Current balance should be = " + (1000.0 + 200 - 10 - 2*2));
    }
}