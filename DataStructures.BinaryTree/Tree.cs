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

    public int Height(Node root)
    {
        if(root == null)
            return -1;

        if (IsLeaf(root)) 
            return 0;

        return 1 + Math.Max(Height(root.Left), Height(root.Right));
    }

    private bool IsLeaf(Node node)
    {
        return node.Left is null && node.Right is null;
    }

    // O(log n) time complexity
    public int Min(Node root)
    {
        if(root is null)
            throw new ArgumentNullException();

        var current = root;
        var last = current;
        while(current is not null)
        {
            last = current;
            current = current.Left;
        }

        return last.Value;
    }

        // O(n) time complexity
    public int MinimumValue(Node root)
    {
        if (root is null)
            return -1;

        if(IsLeaf(root))
            return root.Value;

        var left = MinimumValue(root.Left);
        var right = MinimumValue(root.Right);

        return Math.Min(Math.Min(left, right), root.Value);
    }

    public bool Equals(Tree other)
    {
        return Equals(Root, other.Root);
    }

    private bool Equals(Node first, Node second)
    {
        if (first is null && second is null)
            return true;

        if (first is not null && second is not null)
            return first.Value == second.Value
                && Equals(first.Left, second.Left)
                && Equals(first.Right, second.Right);

        return false;
    }

}