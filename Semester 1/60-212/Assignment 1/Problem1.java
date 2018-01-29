// Assignment 1, Problem 1 Solution

// Starting with a balance of $1000, and at a rate of 5% interest per year,
// this program displays the balance of the account for years 1, 2, and 3.

public class Problem1
{
    public static void main(String[] args)
    {
        int year = 0;          // The current year
        double interest = 0;   // The current year's interest
        double rate = 0.05;    // Interest compounded at 5% annually
        double balance = 1000; // Start with an initial balance of $1000

        // Perform the algorithm for years 1, 2, and 3.
        // Note that the inequality is strict because the year is post-incremented.
        while (year < 3)
        {
            // Increase the year count
            year++;

            // Compute interest = balance * 0.05.
            interest = balance * rate;

            // Set balance = balance + interest.
            balance = balance + interest;

            // Print the balance for the current year.
            System.out.println("Year " + year + " balance = " + balance);
        }
    }
}