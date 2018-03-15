import java.io.*;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class A1_104014257
{
    // This contains all of the reserved C language keywords.
    private static String[] languageKeywords = {
            "int",
            "short",
            "float",
            "char",
            "auto",
            "struct",
            "break",
            "else",
            "long",
            "switch",
            "case",
            "enum",
            "register",
            "typedef",
            "extern",
            "return",
            "union",
            "const",
            "unsigned",
            "continue",
            "for",
            "signed",
            "void",
            "default",
            "goto",
            "sizeof",
            "volatile",
            "do",
            "if",
            "static",
            "while",
    };

    // This contains a list of commonly reserved identifiers in C
    private static String[] reservedIdentifiers = {
            "main",
            "printf",
    };

    /**
     * Test if a given string is a C language identifier.
     * @param s the string to test.
     * @return true if the string is a C language keyword, and false otherwise.
     */
    private static boolean isLanguageKeyword(String s)
    {
        for (String keyword : languageKeywords)
            if (keyword.equals(s))
                return true;

        return false;
    }

    /**
     * Test if a given string is a reserved C identifier.
     * @param s the string to test.
     * @return true if the identifier is reserved, and false otherwise.
     */
    private static boolean isReservedIdentifier(String s)
    {
        for (String identifier : reservedIdentifiers)
            if (identifier.equals(s))
                return true;

        return false;
    }

    /**
     * Find any substrings of a given string and remove any text between the starting
     * and ending quotes, including the quotes themselves.
     * @param s the string to remove any quoted substrings from.
     * @return the original string without any quoted substrings.
     */
    private static String removeQuotedSubstrings(String s)
    {
        // Find any substring in s matching the given regex pattern, and replace it with the empty string.
        // Note that .* means match anything, hence .*? means anything or nothing. Thus, pairs of quotes are also
        // removed.
        s = s.replaceFirst("\".*?\"", "\"");
        return s;
    }

    /**
     * Return a list of valid C identifiers found within the given string of text.
     * @param line The line of text to parse.
     * @return An ArrayList of strings containing new valid C identifiers.
     */
    private static ArrayList<String> getCIdentifiers(String line)
    {
        // Compile the regex pattern to match against valid C identifiers.
        // The regex pattern for C identifiers can be described by the regex definitions:
        // letters_ -> _ | a | b | ... | z | A | ... | Z
        // digits -> 0 | 1 | ... | 9
        // identifier -> letters_ (letters_ | digits)*
        // That is, a C identifier is one that starts with any of the letters, or underscore, followed by
        // zero or more of letters, underscores, or digits.
        Pattern variableDefinition = Pattern.compile(
                "([_a-zA-Z][_a-zA-Z0-9]*)+"
        );

        // Remove any quoted substrings from the given text. (Those being "quoted substring" within the line of text).
        line = removeQuotedSubstrings(line);

        // Get a regex matcher from the variableDefinition regex pattern.
        Matcher matcher = variableDefinition.matcher(line);

        // The list of matched identifiers.
        ArrayList<String> identifiers = new ArrayList<>();

        // Loop while there are still existing regex groups that were matched,
        while (matcher.find())
        {
            // Test if the matched identifier is a language keyword, or if it is
            // a reserved identifier.
            if (
                    !isLanguageKeyword(matcher.group(1))    &&
                            !isReservedIdentifier(matcher.group(1)) &&
                            matcher.group(1) != null)
            {
                // If the identifier is not a language keyword or a reserved identifier,
                // then add it to the list of new identifiers to consider.
                identifiers.add(matcher.group(1));
            }
        }

        return identifiers;
    }

    /**
     * Find all the unique identifiers for the given file.
     * @param filename the path to the file to parse.
     * @return an ArrayList of strings containing the list of unique identifiers.
     */
    private static ArrayList<String> findUniqueIdentifiers(String filename)
    {
        // Initialize buffered reader and uniqueIdentifiers ArrayList.
        ArrayList<String> uniqueIdentifiers = new ArrayList<>();
        BufferedReader reader = null;

        try
        {
            // Open a new file with the given path
            File file = new File(filename);

            // Create a new BufferedReader to be able to read from the given file.
            reader = new BufferedReader(new FileReader(file));

            // Line buffer to hold read-in data.
            String line;

            // If reader.readLine returns null, then there is no more data to read.
            while ((line = reader.readLine()) != null)
            {
                // Get the list of valid C identifiers for the given line.
                ArrayList<String> identifiers = getCIdentifiers(line);

                // Consider each of the new identifiers
                for (String identifier : identifiers)
                {
                    // If given identifier is not already in our list of unique identifiers, and it is not null,
                    // then not add it to our uniqueIdentifiers list.
                    if (identifier != null && !uniqueIdentifiers.contains(identifier))
                        uniqueIdentifiers.add(identifier);
                }
            }
        } // Catch any IO errors
        catch (IOException e) {
            e.printStackTrace();
        }
        finally {
            // Attempt to close the file reader.
            try {
                if (reader != null)
                    reader.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        return uniqueIdentifiers;
    }


    /**
     * Write the number of unique C language identifiers that were found.
     * @param filename the file to write to.
     * @param numberOfIdentifiers the number of identifiers to write.
     */
    private static void writeNumberofIdentifiers(String filename, int numberOfIdentifiers)
    {
        // Initialize writer to null.
        BufferedWriter writer = null;

        try
        {
            // Open a new file with the given filename.
            File file = new File(filename);

            // If the file does not already exist, then create it.
            if (!file.exists())
                file.createNewFile();

            // Create a writer for the given file.
            writer = new BufferedWriter(new FileWriter(file));

            // Writer the number of distinct identifiers that were found in the input file.
            writer.write("distinct/unique identifiers: " + numberOfIdentifiers);
        }
        catch (IOException e) {
            e.printStackTrace();
        }
        finally {
            // Attempt to close the file writer.
            try {
                if (writer != null)
                    writer.close();
            }
            catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * The entry point of the program.
     * @param args the command line arguments.
     */
    public static void main(String[] args)
    {
        // There must be at least 1 command line argument to specify the input file to parse.
        if (args.length < 1)
        {
            System.out.println("Invalid command-line arguments");
            System.out.println("Usage: java A1_104014257 <input file>");
            return;
        }

        // inputFile is the path to the input file.
        String inputFile = args[0];

        // Read the file and obtain all of the unique C language identifiers.
        ArrayList<String> uniqueIdentifiers = findUniqueIdentifiers(inputFile);

        // Take the input filename and replace the "input" substring with "output". This is our output file.
        // We use regex to essentially retrieve the input file identifier, i.e.: A11, A12, etc.
        String outputFile = inputFile.replaceFirst("A1([0-9])+-input.txt", "A1$1-output.txt");
        writeNumberofIdentifiers(outputFile, uniqueIdentifiers.size());
    }
}
