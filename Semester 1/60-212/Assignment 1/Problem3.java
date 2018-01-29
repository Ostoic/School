// Assignment 1, Problem 3 Solution

public class Problem3
{
    // Computes the sum of the first five negative integers
    // @return sum of the first five negative integers
    static int sumFirstFiveNeg()
    {
        return -1 + -2 + -3 + -4 + -5;
    }
    // Computes the product of the first five negative integers
    // @return product of the first five negative integers
    static int multiplyFirstFiveNeg()
    {
        return -1 * -2 * -3 * -4 * -5;
    }

    public static void main(String[] args) throws Exception
    {
        // Display the sum of the first five negative integers
        System.out.println("Sum of first five negative integers = " + sumFirstFiveNeg());

        // Display the product of the first five negative integers
        System.out.println("Product of first five negative integers = " + multiplyFirstFiveNeg());
    }
}