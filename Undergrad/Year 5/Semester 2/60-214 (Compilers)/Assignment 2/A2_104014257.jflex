import java.util.*;
import java.io.*;
%%
%{
	/* Opens the given file, lexes it, then writes the number of matched productions */
	public static void main(String [] args) throws java.io.IOException 
	{
		A2_104014257 yy = new A2_104014257(new FileReader(args[0]));
		Writer.outputFileName = args[0].replaceAll("input","output");
		while (0 <= yy.yylex());
	}
%}

%{
	ArrayList<String> identifiers = new ArrayList<String>();
	ArrayList<String> keywords = new ArrayList<String>();
	ArrayList<String> numbers = new ArrayList<String>();
	ArrayList<String> comments = new ArrayList<String>();
	ArrayList<String> stringLiterals = new ArrayList<String>();
%}

%{
	static class Writer{
	public static String outputFileName;
	
		FileWriter w;
			Writer(){
			try{ w=new FileWriter(outputFileName);}catch(Exception e)
			{} 
		}
	}
%}


%eof{
try{
	/* Create a writer class that writes the number of identifiers, keywords, numbers, comments, and string literals to the given file. */
	Writer x = new Writer();
	x.w.write("identifiers: " + identifiers.size() + "\r\n");
	x.w.write("keywords: " + keywords.size() + "\r\n");
	x.w.write("numbers: " + numbers.size() + "\r\n");
	x.w.write("comments: " + comments.size() + "\r\n");
	x.w.write("stringLiterals: " + stringLiterals.size() + "\r\n");
	x.w.close();
}catch(Exception e){}
return;
%eof}

%integer
%class A2_104014257

/* Include both multiline comments in a format similar to this one */
/* Also consider the standard inline comment consisting of two consecutive forward slashes*/
Comment = {InlineComment} | {MultilineComment}
MultilineComment = "/*"( [^*] | (\*+[^*/]) )*\*+\/
InlineComment = \/[\/]+.*

/* A short list of commonly used C keywords, including printf for simplicity's sake */
Keyword = if|else|do|while|for|int|short|double|printf|float

/* String literals are in the format: "consider anything here except for double quotes" */
StringLiteral = \"([^\"])*\"

/* The usual C identifier regex */
Identifiers = [a-zA-Z_][a-zA-Z0-9_]*

/* Consider floating-point numbers written in scientific notation or otherwise */
/* [0-9]+ catches regular integers such as 921*/
/* [0-9]*[\.]? catches decimal numbers. The following [0-9]+ means there must be a digit after the decimal */
/* E[+-]+[0-9]+ catches scientific notation E followed by + or -, then followed by one or more digits. */
Numbers = [0-9]*[\.]?[0-9]+(E[+-]+[0-9]+)?

%%
/* These are all checked for uniqueness in their respective ArrayList s */
{Comment} {if (!comments.contains(yytext())) comments.add(yytext());}
{StringLiteral} {if (!stringLiterals.contains(yytext())) stringLiterals.add(yytext());}
{Keyword} {if (!keywords.contains(yytext())) keywords.add(yytext());}
{Identifiers} {if (!identifiers.contains(yytext())) identifiers.add(yytext());}
{Numbers} {if (!numbers.contains(yytext())) numbers.add(yytext());}
\r|\n { /* Do nothing */}
. {/* Do nothing */}