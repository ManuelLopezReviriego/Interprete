using System;

class Token
{
    private TokenType type;
    private string value;

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

enum TokenType { INTEGER, PLUS, MINUS, EOF }
