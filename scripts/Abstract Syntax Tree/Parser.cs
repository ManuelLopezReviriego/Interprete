using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Syntax_Tree
{
    class Parser
    {
        private Lexer lexer;
        private Token currentToken;

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            currentToken = this.lexer.CurrentToken;
        }

        public Node Parse()
        {
            return Expression();
        }

        private Node Expression()
        {
            Node node = Term();

            while (lexer.CurrentToken.Type == TokenType.PLUS || lexer.CurrentToken.Type == TokenType.MINUS)
            {
                Token currentToken = lexer.CurrentToken;
                if (currentToken.Type == TokenType.PLUS)
                {
                    lexer.EatToken(TokenType.PLUS);
                }
                else
                {
                    lexer.EatToken(TokenType.MINUS);
                }

                node = new BinaryOperatorNode(node, currentToken, Term());
            }

            return node;
        }

        private Node Term()
        {
            Node node = Factor();

            while (lexer.CurrentToken.Type == TokenType.MUL || lexer.CurrentToken.Type == TokenType.DIV)
            {
                Token currentToken = lexer.CurrentToken;
                if (lexer.CurrentToken.Type == TokenType.MUL)
                {
                    lexer.EatToken(TokenType.MUL);
                }
                else if (lexer.CurrentToken.Type == TokenType.DIV)
                {
                    lexer.EatToken(TokenType.DIV);
                }

                node = new BinaryOperatorNode(node, currentToken, Factor());
            }

            return node;
        }

        private Node Factor()
        {
            Token temp = lexer.CurrentToken;

            if (temp.Type == TokenType.PLUS)
            {
                lexer.EatToken(TokenType.PLUS);
                return new UnaryOperatorNode(Factor(), temp);
            }
            else if (temp.Type == TokenType.MINUS)
            {
                lexer.EatToken(TokenType.MINUS);
                return new UnaryOperatorNode(Factor(), temp);
            }
            if (temp.Type == TokenType.INTEGER)
            {
                lexer.EatToken(TokenType.INTEGER);
                return new NumberNode(Convert.ToInt32(temp.Value));
            }
            else if (temp.Type == TokenType.LEFT_PAR)
            {
                Node res;
                lexer.EatToken(TokenType.LEFT_PAR);
                res = Expression();
                lexer.EatToken(TokenType.RIGHT_PAR);
                return res;
            }
            throw new Exception("Error: Unknown symbol '" + lexer.CurrentToken.Type + "'");
        }
    }
}
