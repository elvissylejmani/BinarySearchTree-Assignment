using System;

namespace ConsoleApp1
{

    class Node
    {
        private int Vl;
        public int Lev;
        public Node Parent, LC, RC;
        public Node()
        {
            this.Parent = this.LC = this.RC = null;
            this.Lev = -1;
        }
        public Node(int x)
        {
            this.Vl = x;
            this.Parent = this.LC = this.RC = null;
            this.Lev = -1;
        }
        public int BValue
        {
            get { return this.Vl; }
            set { this.Vl = value; }
        }
        public int Level
        {
            get { return this.Lev; }
            set { this.Lev = value; }
        }
    }
    class BST
    {
        public Node root;
        public int MaxNiv;
        public BST()
        {
            this.root = null;
            this.MaxNiv = -1;
        }
        public void insert(int x)
        {
            Node nd = new Node(x);
            if(this.root == null)
            {
                root = nd;
                nd.Level = 0; 
            }
            else
            {
                Node tmproot = root;
                while(tmproot.LC != null || tmproot.RC != null)
                {
                    if(nd.BValue > tmproot.BValue)
                    {
                        if (tmproot.RC != null)
                            tmproot = tmproot.RC;
                        else
                            break;
                    }
                    else
                    {
                        if (tmproot.LC != null)
                            tmproot = tmproot.LC;
                        else
                            break;
                    }

                }
                if (nd.BValue > tmproot.BValue)
                {
                    tmproot.RC = nd;
                    nd.Parent = tmproot;
                    nd.Level = tmproot.Level + 1;
                }
                else
                {
                    tmproot.LC = nd;
                    nd.Parent = tmproot;
                    nd.Level = tmproot.Level + 1;
                }
                if (this.MaxNiv < nd.Level)
                    this.MaxNiv = nd.Level;
            }
        }
        public void show()
        {
            Node nd = root;
            show(nd);
        }
        public void show(Node nd)
        {
            if(nd != null)
            {
                show(nd.LC);
                Console.WriteLine(nd.BValue);
                show(nd.RC);
            }
        }
        public int findlevel()
        {
            Node nd = root;
            return findlevel(nd);
             
        }
        int maxlevelrec = -1;
        public int findlevel(Node nd)
        {

            if (nd == null) return 0;

            if (maxlevelrec < nd.Lev)
                maxlevelrec = nd.Lev;
            findlevel(nd.LC);
            findlevel(nd.RC);

            return maxlevelrec;
          /*  if (nd == null) return 0;

            int leftdepth = findlevel1(nd.LC);
            int rightdepth = findlevel1(nd.RC);

            if (leftdepth > rightdepth)
                return (leftdepth + 1);
            else
                return (rightdepth + 1);
          */

            /*
            if (nd == null) return Treelevel;
            if(nd.Parent != null)
            if (nd.Lev > nd.Parent.Lev)
            {
                findlevel(nd.LC, Treelevel +1);
                findlevel(nd.RC, Treelevel +1);

            }
          
                findlevel(nd.LC, Treelevel);
                findlevel(nd.RC, Treelevel);

            return Treelevel;*/
            
            
            /*if (Treelevel < nd.Lev) return Treelevel + 1;
            if(nd != null)
            {
                if (Treelevel < nd.Lev)
                    Treelevel = nd.Lev;
                Console.WriteLine(Treelevel);
           return   findlevel(nd.LC, Treelevel);
               return  findlevel(nd.RC, Treelevel);
            }
            return Treelevel;*/
           
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BST btree = new BST();
            btree.insert(4);
            btree.insert(3);
            btree.insert(2);
            btree.insert(5);
            btree.insert(6);
            btree.insert(10);
            btree.insert(7);
            btree.insert(11);
            btree.insert(8);

            Console.WriteLine("Leveli i pemes me metode rekursive: " + btree.findlevel());
            Console.WriteLine("Leveli i pemes duke e rritur levelin ne metodent insert: " + btree.MaxNiv);
            Console.ReadLine();
        }
    }
}
