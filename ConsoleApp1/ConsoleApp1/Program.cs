using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int count = 0;
        static void PrintArray(int[,] tab)
        {
            Console.WriteLine();
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
                    Console.Write("{0} ", tab[i, j]);
                }
                Console.Write("\n");
            }
        }

        static void CheckRelation(int[,] tab)
        {
            //Console.WriteLine("Check");
            bool isValid = true;
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
                    //Console.WriteLine("{0}, {1}, value {2}, {3}", i, j, tab[i,j],tab[j,i]);
                    if (i == j)
                    {
                        if (tab[i, j] != 1)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        if (tab[i, j] != tab[j, i])
                        {
                            isValid = false;
                            break;
                        }
                    }                      
                }
                if (!isValid)
                    break;
            }
            if (isValid)
            {
                PrintArray(tab);
                count++;
            }
        }

        static void MakeRelations(int[,] tab, int n, int row, int column)
        {
            if (column == n)
            {
                return;
            }
            if (row == n)
            {
                MakeRelations(tab, n, 0, column + 1);
                return;
            }
            tab[row,column] = 1;
            MakeRelations(tab, n,row + 1, column); //start with a fresh counter
            CheckRelation(tab);
            tab[row, column] = 0; //try with false at the given coordinates
            MakeRelations(tab, n, row + 1, column);
            return;

        }

        static void Main(string[] args)
        {
            int n;
            do
            {
                count = 0;
                Console.Clear();
                Console.WriteLine("\nPROGRAM DEFINIUJĄCY RELACJE ZWROTNE I SYMETRYCZNE DLA PODANEGO N (MAX 5)");
                Console.WriteLine("\n\t****************************\n");
                
                Console.Write("Podaj n dla jakiego mają zostać zdefiniowane relacje (2-5): ");
                do
                {
                    Int32.TryParse(Console.ReadLine(), out n);
                    if (n < 2 || n > 5)
                        Console.Write("Podaj liczbę z zakresu 2-5: ");
                } while (n < 2 || n > 5);
                int[,] tab = new int[n, n];
                Console.Clear();
                Console.WriteLine("Relacje zwrotne i symetryczne dla n = {0}:", n);
                MakeRelations(tab, n, 0, 0);
                Console.WriteLine("\nLiczba relacji zwrotnych i symetrycznych dla n = {0}: {1}", n, count);
                Console.WriteLine("\nAby zakończyć wciśnij klawisz Esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
