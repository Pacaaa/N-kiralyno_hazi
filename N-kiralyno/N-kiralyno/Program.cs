using System;

namespace Sakk
{
    class Program
    {
        static int N = 8;

        static int[,] sakktabla = new int[N, N];

        static bool EgyMezoEllenorzes(int sor, int oszlop)
        {
            int r, c;

           //oszlopok
            for (r = 0; r < N; r++)
            {
                if (sakktabla[sor, r] == 1)
                    return false;
            }

            //sorok
            for (c = 0; c < N; c++)
            {
                if (sakktabla[c, oszlop] == 1)
                    return false;
            }

            //atlok
            for (r = 0; r < N; r++)
            {
                for (c = 0; c < N; c++)
                {
                    if (Math.Abs(r - sor) == Math.Abs(c - oszlop) && sakktabla[r, c] == 1)
                        return false;
                }
            }

            //ellenorzes jo
            return true;
        }

        static bool MezokEllenorzes(int sor)
        {
            //van e hely
            if (sor >= N)
                return true;

           //probalkozas
            for (int oszlop = 0; oszlop < N; oszlop++)
            {
                //jo a mezo
                if (EgyMezoEllenorzes(sor, oszlop))
                {
                    sakktabla[sor, oszlop] = 1;

                    // következő sor
                    if (MezokEllenorzes(sor + 1))
                        return true;

                   
                    sakktabla[sor, oszlop] = 0; // kiralyno torolve
                }
            }

            //nincs tobb lehetseges hely
            return false;
        }

        public static void Main()
        {
            Console.WriteLine("Adja meg a sakktábla méretét:");
            N = Convert.ToInt32(Console.ReadLine());

            sakktabla = new int[N, N];

            if (MezokEllenorzes(0) == false)
            {
                Console.WriteLine("Nincs megoldás!");
                return;
            }

            Console.WriteLine("Az elrendezés: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++) {
                    Console.Write(sakktabla[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
              

            }
        }
    }
}