/**
 * Microwave represents a microwave that can be used to cook food.
 */
public class Microwave
{
    private int powerLevel; // can be 1 or 2
    private int timeToCook; // in seconds

    private long startTime;

    /**
     * Default constructor with powerLevel as 1, and 0 startTime, timeToCook.
     */
    public Microwave()
    {
        this.powerLevel = 1;
        this.timeToCook = 0;
        this.startTime  = 0;
    }

    /**
     *
     * @param cookingTime the time the microwave will cook
     */
    public Microwave(int cookingTime)
    {
        this.powerLevel = 1;
        this.timeToCook = cookingTime;
        this.startTime  = 0;
    }

    /**
     * Start the microwave
     */
    public void start()
    {
        this.startTime = System.currentTimeMillis();
        System.out.println("Cooking for " + this.timeToCook + " second(s) at level " + this.powerLevel);
    }

    /**
     * Gets the current running time of the microwave's cooking session
     * @return the time (in seconds) since starting the microwave
     */
    public long timeElapsed()
    {
        return (System.currentTimeMillis() - this.startTime) / 1000;
    }

    /**
     * Reset the start and cooking times
     */
    public void reset()
    {
        this.timeToCook = 0;
        this.startTime = 0;
    }

    /**
     *  Switch between power levels 1 or 2
     */
    public void switchPowerLevel()
    {
        // If power level is 1, set this.powerLevel to 3 - 1 = 2.
        // If power level is 2, set this.powerLevel to 3 - 2 = 1.
        this.powerLevel = (3 - this.powerLevel);
    }

    /**
     * Increase cooking time
     */
    public void increaseTime()
    {
        this.timeToCook += 30;
    }

}
