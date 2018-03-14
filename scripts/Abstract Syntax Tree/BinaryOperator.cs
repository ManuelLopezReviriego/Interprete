
namespace Abstract_Syntax_Tree
{
    class BinaryOperatorNode : Node
    {
        private Token op;
        private Node left, right;

        public TokenType Type => op.Type;

        public Node LeftChild => left;
        public Node RightChild => right;

        public BinaryOperatorNode(Node lt, Token op, Node rt)
        {
            left = lt;
            this.op = op;
            right = rt;
        }
    }
}
