using DSW;

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        // Insira 100 números aleatórios na árvore
        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            tree.Insert(random.Next(0, 101));
        }

        Console.WriteLine("Árvore antes do balanceamento:");
        tree.InOrderTraversal(tree.Root);

        // Balanceie a árvore usando o algoritmo DSW
        tree.DSWBalance();

        Console.WriteLine("\nÁrvore após o balanceamento:");
        tree.InOrderTraversal(tree.Root);

        // Adicione 20 números à árvore
        for (int i = 0; i < 20; i++)
        {
            tree.Insert(random.Next(0, 101));
        }

        Console.WriteLine("\nÁrvore após adicionar 20 números:");
        tree.InOrderTraversal(tree.Root);
    }
}