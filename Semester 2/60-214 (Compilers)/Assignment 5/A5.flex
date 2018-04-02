import java_cup.runtime.*;
import java.util.*;
import java.io.*;
import java.lang.System;

%%

%function next_token
%class A5Scanner
%cup

%eofval{
          return null;
%eofval}
%state COMMENTS, INLINECOMMENTS, HASH


ID = [a-zA-Z_][a-zA-Z0-9_]*
NUMBER = -?[0-9]+(\.[0-9]+)?([eE][\-\+][0-9]+)?

%%

<YYINITIAL>"void"		{ return new java_cup.runtime.Symbol( A5Symbol.VOID); }
<YYINITIAL>"int"		{ return new java_cup.runtime.Symbol( A5Symbol.INT); }
<YYINITIAL>"return"		{ return new java_cup.runtime.Symbol( A5Symbol.RETURN); }
<YYINITIAL>"main"		{ return new java_cup.runtime.Symbol( A5Symbol.MAIN); }
<YYINITIAL>"if"			{ return new java_cup.runtime.Symbol( A5Symbol.IF); }
<YYINITIAL>"else"		{ return new java_cup.runtime.Symbol( A5Symbol.ELSE); }
<YYINITIAL>"for"		{ return new java_cup.runtime.Symbol( A5Symbol.FOR); }
<YYINITIAL>"while"		{ return new java_cup.runtime.Symbol( A5Symbol.WHILE); }
<YYINITIAL>"+"          { return new java_cup.runtime.Symbol( A5Symbol.PLUS); }
<YYINITIAL>"++"          { return new java_cup.runtime.Symbol( A5Symbol.INCREMENT); }
<YYINITIAL>"-"          { return new java_cup.runtime.Symbol( A5Symbol.MINUS); }
<YYINITIAL>"--"          { return new java_cup.runtime.Symbol( A5Symbol.DECREMENT); }
<YYINITIAL>"*"          { return new java_cup.runtime.Symbol( A5Symbol.PRODUCT); }
<YYINITIAL>"/"          { return new java_cup.runtime.Symbol( A5Symbol.DIVIDE); }
<YYINITIAL>"<"          { return new java_cup.runtime.Symbol( A5Symbol.LT); }
<YYINITIAL>">"          { return new java_cup.runtime.Symbol( A5Symbol.GT); }
<YYINITIAL>">="          { return new java_cup.runtime.Symbol( A5Symbol.GTE); }
<YYINITIAL>"<="          { return new java_cup.runtime.Symbol( A5Symbol.LTE); }
<YYINITIAL>";"          { return new java_cup.runtime.Symbol( A5Symbol.SEMI); }
<YYINITIAL>","          { return new java_cup.runtime.Symbol( A5Symbol.COMMA); }
<YYINITIAL>"("          { return new java_cup.runtime.Symbol( A5Symbol.LPAR); }
<YYINITIAL>")"          { return new java_cup.runtime.Symbol( A5Symbol.RPAR); }
<YYINITIAL>"{"          { return new java_cup.runtime.Symbol( A5Symbol.LBRA); }
<YYINITIAL>"}"          { return new java_cup.runtime.Symbol( A5Symbol.RBRA); }
<YYINITIAL>"="			{ return new java_cup.runtime.Symbol( A5Symbol.EQUAL); }
<YYINITIAL>"printf"		{ return new java_cup.runtime.Symbol( A5Symbol.PRINTF); }
<YYINITIAL>{ID}         { return new java_cup.runtime.Symbol( A5Symbol.ID,yytext());}
<YYINITIAL>{NUMBER}		{ return new java_cup.runtime.Symbol( A5Symbol.NUMBER, yytext());}
<YYINITIAL>\"[^\"]*\"   { return new java_cup.runtime.Symbol( A5Symbol.QUOTES, yytext()); }

<YYINITIAL>"/*" {yybegin(COMMENTS);}
<COMMENTS>"*/" {yybegin(YYINITIAL); }
<COMMENTS>. {}

<YYINITIAL>"//" {yybegin(INLINECOMMENTS);}
<INLINECOMMENTS>"\r"|"\n" {yybegin(YYINITIAL); }
<INLINECOMMENTS>. {}

<YYINITIAL>"#" {yybegin(HASH);}
<HASH>"\r"|"\n" {yybegin(YYINITIAL); }
<HASH>. {}

\r|\n {/* Do nothing */}
. {/* Do nothing */}
