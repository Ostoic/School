package com.company;

/**
 * Class representing a credit card number, that also provides validity checks.
 */
public class CreditCardNumber
{
    private int[] digitList;

    CreditCardNumber(String numberString)
    {
        this.digitList = new int[16];
        this.generateDigitList(this.stripCardNumber(numberString));
    }

    /**
     * Strip all spaces and dashes from the given string.
     * @param numberString the string to strip.
     * @return the stripped string.
     */
    private String stripCardNumber(String numberString)
    {
        numberString = numberString.replace(" ", "");
        return numberString.replace("-", "");
    }

    /**
     * Generate array of digits from number string.
     * @param numberString the string to parse.
     */
    private void generateDigitList(String numberString)
    {
        for (int i = 0; i < digitList.length && i < numberString.length(); i++)
            digitList[i] = Integer.parseInt(String.valueOf(numberString.charAt(i)));
    }

    /**
     * Get the sum of every other digit in the card number.
     * @return the sum.
     */
    private int secondDigitSum()
    {
        int sum = 0;
        for (int i = 0; i < digitList.length; i += 2)
            sum += digitList[i];

        return sum;
    }

    /**
     * Count all digits in the card number > 4.
     * @return the number of digits > 4.
     */
    private int countSecondDigitsGreaterThan4()
    {
        int count = 0;

        for (int i = 0; i < digitList.length; i += 2)
        {
            if (digitList[i] > 4)
                count ++;
        }

        return count;
    }

    /**
     * Get the sum of all the digits in the credit card number.
     * @return the sum of the digits.
     */
    private int sumDigits()
    {
        int sum = 0;
        for (int digit : digitList)
            sum += digit;

        return sum;
    }

    /**
     * Check the validity of the credit card number.
     * @return true if the credit card number is valid, false otherwise.
     */
    public boolean isValid()
    {
        int secretCardComputation
                = this.sumDigits()
                + this.secondDigitSum()
                + this.countSecondDigitsGreaterThan4();

        // Return if the result is divisible by 10.
        return secretCardComputation % 10 == 0;
    }
}
