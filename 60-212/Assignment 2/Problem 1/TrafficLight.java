import java.awt.*;
import java.awt.geom.Ellipse2D;
import java.awt.geom.Rectangle2D;
import java.lang.reflect.Array;
import java.util.Vector;

public class TrafficLight
{
    private Color color;
	
    private int x, y;
    private int width, height;

    /**
     * Constructs a traffic light with the given ccoordinates and color (state)
     * @param x the x of the top left corner
     * @param y the y of the top left corner
     * @param color the color of the traffic light
     */
    TrafficLight(int x, int y, int width, int height, Color color)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.color = color;
    }

    /**
     * Get the width of the traffic light
     * @return the width
     */
    public int getWidth()
    {
        return this.width;
    }

    /**
     * Get the height of the traffic light
     * @return the height
     */
    public int getHeight()
    {
        return this.height;
    }

    /**
     * Draws the traffic light
     * @param g2 the graphics context
     */
    public void draw(Graphics2D g2)
    {
        int lightWidth = this.width - 5;
        int lightHeight = this.height / 3 - 5;
        int heightOffset = 4;

		// Construct the outer shell of traffic light
        Rectangle shell  = new Rectangle(this.x, this.y, this.width, this.height);

		// Construct the red circle
        Ellipse2D.Double redLight
                = new Ellipse2D.Double(this.x + 2, this.y + heightOffset, lightWidth, lightHeight);

		// Construct the yellow circle
        Ellipse2D.Double yellowLight
                = new Ellipse2D.Double(this.x + 2, redLight.getY() + lightHeight + heightOffset, lightWidth, lightHeight);

		// Construct the green circle
        Ellipse2D.Double greenLight
                = new Ellipse2D.Double(this.x + 2, yellowLight.getY() + lightHeight + heightOffset, lightWidth, lightHeight);

        // Draw the outlines of all the shapes
        g2.draw(shell);
        g2.draw(redLight);
        g2.draw(yellowLight);
        g2.draw(greenLight);

        // Determine the light to activate based on which color was chosen
        g2.setColor(this.color);
        if (this.color == Color.RED)
            g2.fill(redLight);

        else if (this.color == Color.YELLOW)
            g2.fill(yellowLight);

        else if (this.color == Color.GREEN)
            g2.fill(greenLight);
        /**
         * Restore the previous graphics color
         */
        g2.setColor(Color.BLACK);
    }
}
