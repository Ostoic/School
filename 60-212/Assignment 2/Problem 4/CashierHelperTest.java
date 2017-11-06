/** Unit test for the cashier helper from problem 4
  */
public class CashierHelperTest
{
    public static void main(String[] args)
    {
		// Customer purchased item that costs $5.72
		// but gave the cashier a $10 bill
        CashierHelper change1 = new CashierHelper(572, 1000);
        System.out.println("Customer is buying item with price of $5.72");
        System.out.println("Customer has given the cashier a $10 bill");
        System.out.println("Change due: " + change1.toString());
		
		// Amount Leftover: 1000 - 572 = 428
		// Change decomposition: 4 * 100 + 1 * 25 + 3*1 = 428
        System.out.println("Expected change: " + "4 dollars " + "1 quarter " + "3 pennies");
        System.out.println();

		// Customer purchased item that costs $1.41
		// but gave the cashier a $15 bill
        CashierHelper change2 = new CashierHelper(141, 1500);
        System.out.println("Customer is buying item with price of $1.41");
        System.out.println("Customer has given the cashier a $15 bill");
        System.out.println("Change due: " + change2.toString());
		
		// Amount Leftover: 1500 - 141 = 1359
		// Change decomposition: 13 * 100 + 2 * 25 + 1*5 + 4*1 = 1359
        System.out.println("Expected change: " + "13 dollars " + "2 quarters " + "1 nickel " + "4 pennies");
        System.out.println();

		// Customer purchased item that costs $14.20
		// but gave the cashier a $20 bill
        CashierHelper change3 = new CashierHelper(1420, 2000);
        System.out.println("Customer is buying item with price of $14.20");
        System.out.println("Customer has given the cashier a $20 bill");
        System.out.println("Change due: " + change3.toString());
		
		// Amount Leftover: 2000 - 1420 = 580
		// Change decomposition: 5 * 100 + 25 * 3 + 1 * 5 = 580
        System.out.println("Expected change: " + "5 dollars " + "3 quarters " + "1 nickel");
        System.out.println();
    }
}