using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Syntax_Tree
{
    class InterpreterAST
    {
        private Parser parser;

        public InterpreterAST(string line)
        {
            Lexer lexer = new Lexer(line);
            parser = new Parser(lexer);
        }

        public int Eval()
        {
            return Eval(parser.Parse()).Value;
        }

        private NumberNode EvalBinOpNode(BinaryOperatorNode node)
        {
            int lt = Eval(node.LeftChild).Value;
            int rt = Eval(node.RightChild).Value;

            if (node.Type == TokenType.PLUS)
            {
                return new NumberNode(lt+rt);
            } else if(node.Type == TokenType.MINUS)
            {
                return new NumberNode(lt - rt);
            } else if (node.Type == TokenType.MUL)
            {
                return new NumberNode(lt * rt);
            } else if (node.Type == TokenType.DIV)
            {
                return new NumberNode(lt / rt);
            }
            throw new Exception("Error: Unknown binary operator");
        }

        private NumberNode EvalUnaryOpNode(UnaryOperatorNode node)
        {
            if(node.Type == TokenType.PLUS)
            {
                return Eval(node.Expression);
            } else if(node.Type == TokenType.MINUS)
            {
                return new NumberNode(-Eval(node.Expression).Value);
            }
            throw new Exception("Error: Unknown unary operator");
        }

        private NumberNode Eval(Node node)
        {
            if(node is BinaryOperatorNode)
            {
                return EvalBinOpNode((BinaryOperatorNode)node);
            }
            else if (node is UnaryOperatorNode)
            {
                return EvalUnaryOpNode((UnaryOperatorNode)node);
            }
            else if(node is NumberNode)
            {
                return (NumberNode) node;
            }
            throw new Exception("Error: Unknown node");
        }
    }
}
