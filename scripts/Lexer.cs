using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Lexer
{
    private string line;
    private int index;
    private Token currentToken;

    public Token CurrentToken => currentToken;

    public Lexer(string line)
    {
        this.line = line;
        index = 0;
        currentToken = NextToken();
    }

    private void SkipWhiteSpaces()
    {
        while (line[index] == ' ')
        {
            index++;
        }
    }

    private int GetInteger()
    {
        string num = "";
        while (index < line.Length && Char.IsDigit(line[index]))
        {
            num += line[index];
            index++;
        }
        return Convert.ToInt32(num);
    }

    public Token NextToken()
    {
        while (index < line.Length)
        {
            char c = line[index];

            if (c == ' ')
            {
                SkipWhiteSpaces();
                continue;
            }

            if (Char.IsDigit(c))
            {
                return new Token(TokenType.INTEGER, GetInteger().ToString()); //
            }

            switch (c)
            {
                case '+':
                    index++;
                    return Token.PLUS;
                case '-':
                    index++;
                    return Token.MINUS;
                case '*':
                    index++;
                    return Token.MUL;
                case '/':
                    index++;
                    return Token.DIV;
                case '(':
                    index++;
                    return Token.LEFT_PAR;
                case ')':
                    index++;
                    return Token.RIGHT_PAR;
            }

            throw new Exception("Error: Unknown symbol '" + c + "'");
        }
        return Token.EOF;
    }

    public void EatToken(TokenType type)
    {
        if (currentToken.Type == type)
        {
            currentToken = NextToken();
        }
        else
        {
            throw new Exception(String.Format("Error: Unexpected token of type '{0}'.", currentToken.Type));
        }
    }
}
