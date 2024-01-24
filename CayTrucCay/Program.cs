using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    //dinh nghia node cua cay
    class TNode
    {
        public int Info;
        public TNode Left;
        public TNode Right;

        public TNode(int x)
        {
            Info = x;
            Left = null;
            Right = null;
        }
    }
    //dinh nghia cay nhi phan
    class SearchBinaryTree
    {
        public TNode Root;
        public SearchBinaryTree()
        {
            Root = null;
        }
        //thao tac duyet cay
        public void NLR(TNode root) //duyet theo thu tu truoc ( Goc, trai, phai)
        {
            if (root != null)
            {
                if (root != null)
                {
                    Console.Write($"{root.Info} -> ");
                    NLR(root.Left);
                    NLR(root.Right);
                }
            }
        }
        public void LNR(TNode root) //duyet theo thu tu giua ( Thu tu tang dan)
        {
            if (root != null)
            {
                if (root != null)
                {
                    LNR(root.Left);
                    Console.Write($"{root.Info} -> ");
                    LNR(root.Right);
                }
            }
        }
        public void LRN(TNode root) //duyet theo thu tu sau ( Trai, phai, goc)
        {
            if (root != null)
            {
                if (root != null)
                {
                    LRN(root.Left);
                    LRN(root.Right);
                    Console.Write($"{root.Info} -> ");
                }
            }
        }
        public void ThemNode(ref TNode root, int x)
        {
            if (root == null)
            {
                TNode p = new TNode(x);
                root = p;
            }
            else if (root.Info > x)
                ThemNode(ref root.Left, x);
            else if (root.Info < x)
                ThemNode(ref root.Right, x);
        }
        //phuong thuc tao cay
        public void TaoCay()
        {
            Console.Write(" Cho biet so nut cua cay: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(" Nhap gia tri node thu " + i + ":");
                int x = int.Parse(Console.ReadLine());
                ThemNode(ref Root, x);
            }
        }
        //phuong thuc tim kiem nut co gia tri x tren cay nhi phan tim kiem
        public TNode TimKiem(TNode root, int x)
        {
            TNode kq = null;
            if (root != null)
            {
                if (root.Info == x)
                    kq = root;
                else if (x < root.Info)
                    kq = TimKiem(root.Left, x);
                else
                    kq = TimKiem(root.Right, x);
            }
            return kq;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SearchBinaryTree tree = new SearchBinaryTree();
            tree.TaoCay();
            Console.WriteLine("Ket qua duyet cay:");
            Console.Write("\n NLR:");
            tree.NLR(tree.Root);

            Console.Write("\n LNR:");
            tree.LNR(tree.Root);

            Console.Write("\n LRN:");
            tree.LRN(tree.Root);

            Console.Write("\n Nhap gia tri nut can tim:");
            int x = int.Parse(Console.ReadLine());
            TNode kq = tree.TimKiem(tree.Root, x);
            if (kq == null)
            {
                Console.WriteLine($"{x} khong xuat hien trong cay");
            }
            else
            {
                Console.WriteLine($"{x} xuat hien trong cay");
            }
            Console.ReadLine();
        }
    }
}