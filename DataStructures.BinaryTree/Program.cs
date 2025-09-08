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

Console.WriteLine("Binary Tree Example");