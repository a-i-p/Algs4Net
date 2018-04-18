using System;

namespace Algs4Net
{
    public class UF_W1Q3_SuccessorWithDelete
    {
        private int[] parent;
        private int count;

        public UF_W1Q3_SuccessorWithDelete(int N)
        {
            if (N <= 0) throw new ArgumentException("Negative number input");
            parent = new int[N];
            count = N;
            for (int i = 0; i < N; i++)
            {
                parent[i] = i;
            }
        }

        private int getRoot(int p)
        {
            validate(p);
            while (p != parent[p])
            {
                parent[p] = parent[parent[p]]; // path compression
                p = parent[p];
            }
            return p;
        }

        private void validate(int p)
        {
            int n = parent.Length;
            if (p < 0 || p >= n)
            {
                throw new IndexOutOfRangeException("index " + p + " is not between 0 and " + (n - 1));
            }
        }

        private void union(int p, int q)
        {
            int rootP = getRoot(p);
            int rootQ = getRoot(q);
            if (rootP == rootQ) return;

            parent[rootP] = rootQ;
        }

        public int GetSuccessor(int x)
        {
            return getRoot(x);
        }

        public void Remove(int x)
        {
            if (x == count - 1) throw new InvalidOperationException("Could not remove the greatest value");

            union(x, x + 1);
        }

        [HelpText("algscmd UF_W1Q3_SuccessorWithDelete")]
        public static void MainTest(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            UF_W1Q3_SuccessorWithDelete uf = new UF_W1Q3_SuccessorWithDelete(N);
            while (true)
            {
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine($"Successor {x} is {uf.GetSuccessor(x)}");
                uf.Remove(x);
                Console.WriteLine($"Successor {x} is {uf.GetSuccessor(x)}");
            };
        }
    }
}
