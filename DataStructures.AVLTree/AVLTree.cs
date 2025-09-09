using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.AVLTree
{
    public class AVLTree
    {
        public class AVLNode
        {
            public int Value;
            public AVLNode Left;
            public AVLNode Right;
            public int Height;  
            public AVLNode(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return "Value = " + Value;
            }
        }

        public AVLNode Root { get; set; }

        public void Insert(int value)
        {
           Root =  Insert(Root, value);
        }
        
        private AVLNode Insert(AVLNode root, int value)
        {
            if(root == null)
                return new AVLNode(value);

            if(value < root.Value)
                root.Left = Insert(Root.Left, value);
            else
                root.Right =  Insert(root.Right, value);

            root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

            int balanceFactor = BalanceFactor(root);

           root = Balance(root);

            return root;
        }

        private AVLNode Balance(AVLNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (BalanceFactor(root.Left) < 0)
                   root.Left =  RotateLeft(root.Left);
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.Right) > 0) 
                   root.Right = RotateRight(root.Right);
                return RotateLeft(root);
            }
            return root;
        }

        private AVLNode RotateRight(AVLNode root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;
            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }
         
        private AVLNode RotateLeft(AVLNode root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;
            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }

        private void SetHeight(AVLNode node) => 
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        private bool IsLeftHeavy(AVLNode root) =>
            BalanceFactor(root) > 1;

        private bool IsRightHeavy(AVLNode root) =>
            BalanceFactor(root) < -1;

        private int BalanceFactor(AVLNode root) => 
            root is null ? 0 : Height(root.Left) - Height(root.Right);
        public int Height(AVLNode root) => 
            root is null ? -1 : root.Height;
    }
}
