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
        static int option = 0;

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

        static void CheckRelationSymmetric(int[,] tab)
        {
            bool isValid = true;
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
                    if (i != j)
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

        static void CheckRelationReflexive(int[,] tab)
        {
            bool isValid = true;
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
                    if (i == j)
                    {
                        if (tab[i, j] != 1)
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

        static void CheckRelationBoth(int[,] tab)
        {
            bool isValid = true;
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                for (int j = 0; j < tab.GetLength(0); j++)
                {
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
            MakeRelations(tab, n,row + 1, column);
            if (option == 1)
                CheckRelationSymmetric(tab);
            else if (option == 2)
                CheckRelationReflexive(tab);
            else if(option == 3)
                CheckRelationBoth(tab);
            tab[row, column] = 0;
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
                Console.WriteLine("1. Relacje symetryczne");
                Console.WriteLine("2. Relacje zwrotne");
                Console.WriteLine("3. Relacje symetryczne i zwrotne");
                Console.Write("\nWybierz opcję: ");
                do
                {
                    Int32.TryParse(Console.ReadLine(), out option);
                    if (option != 1 && option!= 2 && option != 3)
                        Console.Write("Wybierz opcję 1 - 3: ");
                } while (option != 1 && option != 2 && option != 3);
                Console.Write("\nPodaj n dla jakiego mają zostać zdefiniowane relacje (2 - 5): ");
                do
                {
                    Int32.TryParse(Console.ReadLine(), out n);
                    if (n < 2 || n > 5)
                        Console.Write("Podaj liczbę z zakresu 2-5: ");
                } while (n < 2 || n > 5);
                int[,] tab = new int[n, n];
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Relacje symetryczne dla n = {0}:", n);
                    CheckRelationSymmetric(tab);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Relacje zwrotne dla n = {0}:", n);
                    CheckRelationReflexive(tab);
                }
                    
                else if (option == 3)
                {
                    Console.WriteLine("Relacje symetrycze i zwrotne dla n = {0}:", n);
                    CheckRelationBoth(tab);
                }
                MakeRelations(tab, n, 0, 0);
                Console.WriteLine("\nLiczba relacji dla n = {0}: {1}", n, count);
                Console.WriteLine("\nAby zakończyć wciśnij klawisz Esc");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
