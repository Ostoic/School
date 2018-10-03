/**
 * Unit test class for the Microwave class of problem 2
 */
public class MicrowaveTest
{
    public static void main(String[] args)
    {
        Microwave microwave = new Microwave(30);
        microwave.increaseTime(); // Increase time to 90 seconds
        microwave.increaseTime();
        microwave.start();
        System.out.println("Expected microwave start: " + "90 seconds " + "power level 1");
        System.out.println();

        microwave.reset(); // Reset the cooking time
        microwave.increaseTime(); // Increase the cooking time to 30 seconds
        microwave.switchPowerLevel(); // Switch power level from 1 to 2
        microwave.start();
        System.out.println("Expected microwave start: " + "30 seconds " + "power level 2");
        System.out.println();

        microwave.increaseTime(); // Increase cooking time to 60 seconds
        microwave.switchPowerLevel(); // Switch power level from 2 to 1
        microwave.start();
        System.out.println("Expected microwave start: " + "60 seconds " + "power level 1");
        System.out.println();
    }
}