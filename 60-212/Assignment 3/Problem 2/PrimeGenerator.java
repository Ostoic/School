package com.company;

/**
 This class generates all prime numbers.
 */
public class PrimeGenerator
{
    private int current;

    /**
     * Default constructor to generate primes all > 1.
     */
    public PrimeGenerator()
    {
        current = 1;
    }

    /**
     * Constructor to generate primes all > lbound
     * @param lbound the lower bound to generate starting from.
     */
    public PrimeGenerator(int lbound)
    {
        current = lbound;
    }

    /**
     Calculates the next prime number.
     @return the next prime number
     */
    public int nextPrime()
    {
        do {
            current++;
        } while (!isPrime(this.current));

        return this.current;
    }

    /**
     Check if n is a prime number.
     @param n to check whether it is prime or not
     @return true if n is prime
     */
    public static boolean isPrime(int n)
    {
        // Search for divisors of n starting from 2 up to n/2
        for (int x = 2; x < n / 2; x++)
        {
            // Check if x divides n
            if (n % x == 0)
                return false; // If x divides n, then n is prime
        }

        // n has no divisors, hence is a prime number
        return true;
    }
}