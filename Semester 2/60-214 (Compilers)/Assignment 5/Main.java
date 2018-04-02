import java.io.*;
import java_cup.runtime.Symbol;

class Main {
  public static void main(String[] args) throws Exception {
       File inputFile = new File (args[0]);
       A5Parser parser= new A5Parser(new A5Scanner(new FileReader(inputFile)));
       String result = (String)parser.debug_parse().value;
       String outputFileName = args[0].replaceAll("input.c","output.java");
       FileWriter fw = new FileWriter(new File(outputFileName));
       fw.write(result);
       fw.close();
  }
}
