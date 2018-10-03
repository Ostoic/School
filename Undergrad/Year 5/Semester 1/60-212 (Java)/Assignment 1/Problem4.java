// Assignment 1, Problem 4 Solution

import java.net.URL;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;

// Change Test to Problem4 to compile 
public class Test
{
    public static void main(String[] args) throws Exception
    {
        // Get URL object of the cover-art for the Big Java book.
        URL imageLocation = new URL("http://horstmann.com/java4everyone/cover.jpg");

        // Display the text: "Different Greeting", with title "All New Greeting" in a dialog as a plain message, with
        // the specified image icon being that of the image located at the above URL.
        JOptionPane.showMessageDialog(null, "Different Greeting", "All New Greeting",
            JOptionPane.PLAIN_MESSAGE, new ImageIcon(imageLocation));
    }
}