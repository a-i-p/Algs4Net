using System;

namespace Algs4Net
{
    public class UF_W1Q2_CanonicalElement
    {
        private int[] id;
        private int[] sz;
        private int[] gt;

        public UF_W1Q2_CanonicalElement(int N)
        {
            id = new int[N];
            sz = new int[N];
            gt = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
                sz[i] = 1;
                gt[i] = i;
            }
        }

        public int Root(int p)
        {
            while (p != id[p])
                p = id[p];
            return p;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int rootP = Root(p);
            int rootQ = Root(q);
            if (rootP == rootQ) return;

            if (sz[rootP] < sz[rootQ])
            {
                id[rootP] = rootQ;
                sz[rootQ] += sz[rootP];
                if (gt[rootQ] < gt[rootP])
                {
                    gt[rootQ] = gt[rootP];
                }
            }
            else
            {
                id[rootQ] = rootP;
                sz[rootP] += sz[rootQ];
                if (gt[rootP] < gt[rootQ])
                {
                    gt[rootP] = gt[rootQ];
                }
            }
        }

        public int Find(int p)
        {
            return gt[Root(p)];
        }

        [HelpText("algscmd UF_W1Q2_CanonicalElement < tinyUF.txt")]
        public static void MainTest(string[] args)
        {
            TextInput StdIn = new TextInput();
            int N = StdIn.ReadInt();
            UF_W1Q2_CanonicalElement uf = new UF_W1Q2_CanonicalElement(N);
            while (!StdIn.IsEmpty)
            {
                int p = StdIn.ReadInt();
                int q = StdIn.ReadInt();
                if (uf.Connected(p, q)) continue;
                uf.Union(p, q);
                Console.WriteLine($"{p} {q} : {uf.Find(p)}");
            }
        }
    }
}
