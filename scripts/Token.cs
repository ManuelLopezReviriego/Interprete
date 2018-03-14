using System;

class Token
{
    private TokenType type;
    private string value;

    public TokenType Type => type;
    public string Value => value;

    public static Token PLUS => new Token(TokenType.PLUS, "");
    public static Token MINUS => new Token(TokenType.MINUS, "");
    public static Token MUL => new Token(TokenType.MUL, "");
    public static Token DIV => new Token(TokenType.DIV, "");

    public static Token LEFT_PAR => new Token(TokenType.LEFT_PAR, "");
    public static Token RIGHT_PAR => new Token(TokenType.RIGHT_PAR, "");

    public static Token EOF => new Token(TokenType.EOF, "");

    public Token(TokenType type, string value)
    {
        this.type = type;
        this.value = value;
    }

    public override string ToString()
    {
        return String.Format("Token({0}, {1})", type, value);
    }
}

enum TokenType { INTEGER, PLUS, MINUS, MUL, DIV, LEFT_PAR, RIGHT_PAR, EOF }
