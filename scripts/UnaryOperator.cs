using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Syntax_Tree
{
    class UnaryOperatorNode : Node
    {
        private Token op;
        private Node expression;

        public TokenType Type => op.Type;

        public Node Expression => expression;

        public UnaryOperatorNode(Node expr, Token op)
        {
            expression = expr;
            this.op = op;
        }
    }
}
