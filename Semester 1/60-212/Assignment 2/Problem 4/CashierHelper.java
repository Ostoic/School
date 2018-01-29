/**
 * A class to help the cashier with determining the right amount of change to
 * give to customers
 */
public class CashierHelper
{
    private int amountLeft;

    /**
     * Defines how much each coin is worth in cents
     */
    private final int penny   = 1;
    private final int nickel  = 5;
    private final int dime    = 10;
    private final int quarter = 25;
    private final int dollar  = 100;

    /**
     * Default (empty) constructor
     */
    public CashierHelper()
    {
        this.amountLeft = 0;
    }

    /**
     * Creates a new cashier helper
     * @param amountDue the amount that the customer is paying for
     * @param amountReceived the amount that the customer gave to the cashier
     */
    public CashierHelper(int amountDue, int amountReceived)
    {
        this.amountLeft = amountReceived - amountDue;
    }

    /**
     * Gets the number of coins that can be taken from the leftover amount
     * @param coinWorth the coin we would like to extract from amountLeft
     * @return the maximum number of coins left in amountLeft
     */
    private int getCoinCount(int coinWorth)
    {
        int coinCount = this.amountLeft / coinWorth;
        this.amountLeft -= coinCount * coinWorth;
        return coinCount;
    }

    /**
     * Gets the number of pennies that can be taken from the leftover amount
     * @return the number of pennies
     */
    private int getPennies()
    {
        return this.getCoinCount(penny);
    }

    /**
     * Gets the number of nickels that can be taken from the leftover amount
     * @return the number of nickels
     */
    private int getNickels()
    {
        return this.getCoinCount(nickel);
    }

    /**
     * Gets the number of dimes that can be taken from the leftover amount
     * @return the number of dimes
     */
    private int getDimes()
    {
        return this.getCoinCount(dime);
    }

    /**
     * Gets the number of quarters that can be taken from the leftover amount
     * @return the number of quarters
     */
    private int getQuarters()
    {
        return this.getCoinCount(quarter);
    }

    /**
     * Gets the number of dollars that can be taken from the leftover amount
     * @return the number of dollars
     */
    private int getDollars()
    {
        return this.getCoinCount(dollar);
    }

    /**
     * Get the formatted change string for the leftover amount
     * @return the string of change to give back to the customer
     */
    public String toString()
    {
        return Integer.toString(getDollars())   + " dollars "  +
               Integer.toString(getQuarters())  + " quarters " +
               Integer.toString(getDimes())     + " dimes "    +
               Integer.toString(getNickels())   + " nickels "  +
               Integer.toString(getPennies())   + " pennies ";
    }

}
