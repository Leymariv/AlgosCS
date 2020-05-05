namespace Algos
{
    public class NodeTree
    {
        public NodeTree(int value, NodeTree left, NodeTree right)
        {
            Value = value;
            Right = right;
            Left = left;
        }

        public int Value { get; set; }
        public NodeTree Right { get; set; }
        public NodeTree Left { get; set; }
    }
}