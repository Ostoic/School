package com.company;

import java.util.Scanner;

public class CreditCardNumberTester
{
    public static void main(String[] args)
    {
        String number1 = "4012 8888 8888 1881";
        String number2 = "0600-7345 0612 1171";
        String number3 = "4012-1111-8788-1881";

        CreditCardNumber cardNumber1 = new CreditCardNumber(number1);
        CreditCardNumber cardNumber2 = new CreditCardNumber(number2);
        CreditCardNumber cardNumber3 = new CreditCardNumber(number3);

        System.out.println("Card number 1 is valid = " + cardNumber1.isValid());
        System.out.println("Expected result = true");
        System.out.println();

        System.out.println("Card number 2 is valid = " + cardNumber2.isValid());
        System.out.println("Expected result = false");
        System.out.println();

        System.out.println("Card number 3 is valid = " + cardNumber3.isValid());
        System.out.println("Expected result = false");
        System.out.println();

    }
}
