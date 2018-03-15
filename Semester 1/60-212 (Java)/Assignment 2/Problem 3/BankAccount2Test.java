// Unit test for the second version of BankAccount (with monthly charging) from problem 3 
public class BankAccount2Test
{
	public static void main(String[] args)
	{
        BankAccount account = new BankAccount(1000);
        account.deposit(200); // 1 transaction
        for (int i = 0; i < 15; i++)  // 15 transactions (1 charged now)
            account.withdraw(10);
        account.deductMonthlyCharge(); // A month has passed
        System.out.println("Current balance = " + account.getBalance());

        // initial balance of $1000
        // 1 free deposit of $200
        // 14 free withdrawls of $10,
        // 1 charged withdrawl of $10
        System.out.println("Current balance should be = " + (1000.0 + 200 - 10*15 - 1*1));

        account.deposit(300); // 1 free deposit of $300
        account.withdraw(15); // 1 free withdrawl of $15
        account.deductMonthlyCharge(); // A month has passed
        System.out.println("Current balance = " + account.getBalance());
        // From last month, the bank account's balance is 1049
        // 1 free deposit of $300
        // 1 free withdrawl of $15
        System.out.println("Current balance should be = " + (1049.0 + 300 - 15));
	}
}