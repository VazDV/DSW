using System.Runtime.Intrinsics.X86;

namespace DSW
{
    class BinaryTree
    {
        public TreeNode Root;

        public void Insert(int value)
        {
            Root = InsertRecursive(Root, value);
        }

        private TreeNode InsertRecursive(TreeNode root, int value)
        {
            if (root == null)
                return new TreeNode(value);

            if (value < root.Value)
                root.Left = InsertRecursive(root.Left, value);
            else if (value > root.Value)
                root.Right = InsertRecursive(root.Right, value);

            return root;
        }

        public void DSWBalance()
        {
            // Converta a árvore para uma lista encadeada
            Console.WriteLine("\n" + Root.Value);
            Root = FlattenToList(Root);
            // Aplique rotações à direita para equilibrar a lista encadeada
            while (Root != null)
            {
                Root = RotateRight(Root);
            }
        }

        private TreeNode FlattenToList(TreeNode root)
        {
            TreeNode aux = new TreeNode(0);
            aux.Right = root;
            TreeNode current = aux;

            while (current.Right != null)
            {
                if (current.Right.Left == null)
                {
                    Console.WriteLine("\n" + aux.Value);
                    current = RotateRight(current);
                }
                else
                {
                    Console.WriteLine("\n" + aux.Value + "\n" + current.Right.Value);
                    current = RotateRightLeft(current);
                }
            }

            return aux.Right;
        }

        private TreeNode RotateRight(TreeNode root)
        {
            TreeNode newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;
            return newRoot;
        }

        private TreeNode RotateRightLeft(TreeNode parent)
        {
            TreeNode child = parent.Right;
            Console.WriteLine("\n" + child.Value);
            parent.Right = RotateRight(child);
            return RotateRight(parent);
        }

        public void InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Value + " ");
                InOrderTraversal(root.Right);
            }
        }

    }
}
