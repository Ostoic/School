import javax.swing.JFrame;

public class TrafficLightViewer
{
    public static void main(String[] args)
    {
		// Create frame for displaying things
        JFrame frame = new JFrame();
        frame.setSize(415, 370);
        frame.setTitle("Traffic lights");

		// Create traffic light component and add it to the frame
        TrafficLightComponent trafficLights = new TrafficLightComponent();
        frame.add(trafficLights);
        frame.setVisible(true);
    }
}