// Assignment 1, Problem 5 Solution

public class Problem5
{
    public static void main(String[] args)
    {
        // First equation:

        // Declare and initialize variables
        double s_0 = 30; // Initial speed?
        double v_0 = -2; // Initial velocity?
        double g = -9.81; // Gravity?
        double t = 3; // Time?

        // Calculate s using the given formula
        double s = s_0 + v_0 + (1.0 / 2.0) * g * t*t;

        // Display the value of s
        System.out.println(s);

        // Second equation:

        // Declare and initialize variables
        double pi = 3.1415926535897; // pi is assumed to be the greek "pi" letter in the formula
        double a = 3.31, p = 0.52; // Acceleration and __ ?
        double m1 = 10, m2 = 30; // Two masses?

        // Calculate G using the given formula
        double G = 4 * pi * pi * ( a*a*a / (p*p * (m1 + m2)) );

        // Display the value of G
        System.out.println(G);
    }
}