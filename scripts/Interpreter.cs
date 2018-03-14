using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Interpreter
{
    private Lexer lexer;

    public Interpreter(string line)
    {
        lexer = new Lexer(line);
    }

    public int Expression()
    {   
        int result = Term();

        while(lexer.CurrentToken.Type == TokenType.PLUS || lexer.CurrentToken.Type == TokenType.MINUS)
        {
            if(lexer.CurrentToken.Type == TokenType.PLUS)
            {
                lexer.EatToken(TokenType.PLUS);
                result += Term();
            }
            else
            {
                lexer.EatToken(TokenType.MINUS);
                result -= Term();
            }
        }
        return result;
    }

    private int Term()
    {
        int result = Factor();

        while (lexer.CurrentToken.Type == TokenType.MUL || lexer.CurrentToken.Type == TokenType.DIV)
        {
            if(lexer.CurrentToken.Type == TokenType.MUL)
            {
                lexer.EatToken(TokenType.MUL);
                result *= Factor();
            } else if(lexer.CurrentToken.Type == TokenType.DIV)
            {
                lexer.EatToken(TokenType.DIV);
                result /= Factor();
            }
        }

        return result;
    }

    private int Factor()
    {
        Token temp = lexer.CurrentToken;
        if (temp.Type == TokenType.INTEGER)
        {
            lexer.EatToken(TokenType.INTEGER);
            return Convert.ToInt32(temp.Value);
        }
        else if (temp.Type == TokenType.LEFT_PAR)
        {
            int res;
            lexer.EatToken(TokenType.LEFT_PAR);
            res = Expression();
            lexer.EatToken(TokenType.RIGHT_PAR);
            return res;
        }
        throw new Exception("Error: Unknown symbol '" + lexer.CurrentToken.Type + "'");
    }

}