package com.company;

import java.util.Scanner;

/**
 This class prints prime numbers.
 */
public class PrimePrinter
{
    public static void main (String[] args)
    {
        // Ask for upper limit of primes to list.
        Scanner in = new Scanner(System.in);
        System.out.print("Enter upper limit: ");
        int limit = in.nextInt();

        // Create a new PrimeGenerator object.
        PrimeGenerator primeGen = new PrimeGenerator();

        // Get the first prime to display
        int prime = primeGen.nextPrime();

        // Ensure the generated prime number is within the user specified limit.
        while (prime < limit) {
            System.out.println(prime);
            prime = primeGen.nextPrime();
        }
    }
}
