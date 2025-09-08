public class Tree
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public Node(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return "Node = " + Value;
        }
    }

    public Node Root { get; set; }

    public void Insert(int value)
    {
        var node = new Node(value);
        if (Root == null)
        {
            Root = node;
            return;
        }
        var current = Root;

        while (true)
        {
            if(value < current.Value)
            {
                if (current.Left is null)
                {
                    current.Left = node;
                    break;
                }
                current = current.Left;
            }
            else
            {
                if(current.Right is null)
                {
                    current.Right = node;
                    break;
                }
                current = current.Right;
            }
        }
    }

    public bool Find(int value)
    {
        var current = Root;
        while (current is not null)
        {
            if (value < current.Value)
                current = current.Left;
            else if (value > current.Value)
                current = current.Right;
            else
                return true;
        }
        return false;
    }

    public void TranversePreOrder(Node root)
    {
        if (root is null)
            return;

        Console.WriteLine(root.Value);
        TranversePreOrder(root.Left);
        TranversePreOrder(root.Right);
    }

    public void TransverseInOrder(Node root)
    {
        if (root is null)
            return;

        TransverseInOrder(root.Left);
        Console.WriteLine(root.Value);
        TransverseInOrder(root.Right);
    }

    public void TransversePostOrder(Node root)
    {
        if (root is null)
            return;

        TransversePostOrder(root.Left);
        TransversePostOrder(root.Right);
        Console.WriteLine(root.Value);
    }
}