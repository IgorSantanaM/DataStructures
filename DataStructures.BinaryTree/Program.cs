Tree tree = new Tree();
tree.Insert(7);
tree.Insert(4);
tree.Insert(9); 
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);
tree.Find(1);
tree.Find(1000);

Console.WriteLine("InOrder\n");
tree.TransverseInOrder(tree.Root);

Console.WriteLine("PreOrder\n");
tree.TranversePreOrder(tree.Root);

Console.WriteLine("PostOrder\n");
tree.TransversePostOrder(tree.Root);

var height = tree.Height(tree.Root);

Console.WriteLine($"Height: {height}");

var minimum = tree.MinimumValue(tree.Root);

Console.WriteLine($"Minimum: {minimum}");

Console.WriteLine("Binary Tree Example");

Tree tree2 = new Tree();
tree2.Insert(7);
tree2.Insert(4);
tree2.Insert(9);
tree2.Insert(1);
tree2.Insert(6);
tree2.Insert(8);
tree2.Insert(10);

Console.WriteLine(tree.Equals(tree2));