using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueen.TutorialCsharp
{
    public struct Vitri
    {
        public int dong;
        public int cot;
        public Vitri(int d, int c)
        {
            dong = d;
            cot = c;
        }
    };
    class _8Queen
    {
        static _8Queen _instance;
        public static  _8Queen getInstance()
        {
            if (_instance == null)
                _instance = new _8Queen();

            return _instance;
        }

       private List<Vitri> vt = new List<Vitri>();
       private int[,] Banco = new int[8, 8];
       private const int n = 8;        
       private int[] Hau = new int[n];
       private int[] Cot = new int[n];
       private int[] CheoCong = new int[2 * n - 1];
       private int[] CheoTru = new int[2 * n - 1];
       private int index = 56;
       private int count = 0;

       public List<Vitri> Vt
       {
           get { return vt; }
           set { vt = value; }
       }

       public int[,] Banco1
       {
           get { return Banco; }
           set { Banco = value; }
       }
       public int Index
       {
           get { return index; }
           set { index = value; }
       }
       public int Count
       {
           get { return count; }
           set { count = value; }
       } 
       public void Ketqua()
        {
            count++;
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < Hau[i]; j++) Banco[i,j] = 0;
                vt.Add(new Vitri(i, j));
                for (j = Hau[i] + 1; j < n; j++) Banco[i, j] = 0;
            }
        }

        public void KhoiTao()
        {
            int i;
            for (i = 0; i <= n - 1; i++)
            {
                Cot[i] = 1;
            }
            for (i = 0; i <= 2 * n - 2; i++)
            {
                CheoCong[i] = 1;
                CheoTru[i] = 1;
            }
        }

       public void Try(int i)
        {
            for (int j = 0; j < n; j++)
                if ( Cot[j] != 0  &&  CheoCong[i + j] != 0 && CheoTru[i - j + n - 1] != 0)
                {   
                    Hau[i] = j;
                    Cot[j] = 0;
                    CheoCong[i + j] = 0;
                    CheoTru[i - j + n - 1] = 0;

                    if (i == n - 1) 
                    {
                        Ketqua();                       
                    }
                    else Try(i + 1);

                    Cot[j] = 1;
                    CheoCong[i + j] = 1;
                    CheoTru[i - j + n - 1] = 1;
                }
        }

    }
}

   