
using System;

namespace Abstract_Syntax_Tree
{
    class NumberNode : Node
    {
        int value;

        public int Value => value;

        public NumberNode(int value)
        {
            this.value = value;
        }
    }
}
