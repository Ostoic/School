import javax.swing.*;
import java.awt.*;

/**
 * Component of 3 traffic lights
 */
public class TrafficLightComponent extends JComponent
{
    /**
     * Displays 3 traffic lights at a fixed width of 30 units apart
     * @param g the graphics context to draw to
     */
    public void paintComponent(Graphics g)
    {
        Graphics2D g2 = (Graphics2D)g;

        int xOffset = 30;
        int xStart = 15;
        int yStart = 15;
        int width = 100;
        int height = 300;

		// Create the traffic light with its red light active
        TrafficLight redLight = new TrafficLight(xStart, yStart, width, height, Color.RED);
        int x = xStart + redLight.getWidth() + xOffset;
        int y = yStart;

		// Create the traffic light with its green light active
        TrafficLight greenLight = new TrafficLight(x, y, width, height, Color.GREEN);
        x += redLight.getWidth() + xOffset;

		// Create the traffic light with its yellow light active
        TrafficLight yellowLight = new TrafficLight(x, y, width, height, Color.YELLOW);
        x += redLight.getWidth() + xOffset;

		// Draw all traffic lights to the graphics context
        redLight.draw(g2);
        yellowLight.draw(g2);
        greenLight.draw(g2);
    }
}
