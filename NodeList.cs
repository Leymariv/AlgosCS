namespace Algos
{
    public class NodeList
    {
        public int Value { get; private set; }
        public NodeList Next { get; set; }

        public NodeList(int value, NodeList next)
        {
            Value = value;
            Next = next;
        }
    }
}