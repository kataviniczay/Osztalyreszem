using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projektkonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Felkeszito> diakok = new List<Felkeszito>();

            foreach (var d in File.ReadAllLines("Felkészítő.txt"))
            {
                string[] temp = d.Split(';');

                diakok.Add(new Felkeszito(temp));
            }

            Console.Write("Új diákot szeretnél hozzáadni vagy meglévő diákok adatát szeretnéd lekérdezni? (Ha új adat akkor 'new data', ha lekérdezni akkor 'old data')");
            string oldnew = Console.ReadLine();

            if (oldnew == "new data")
            {
                Console.WriteLine("Mennyi diákot szeretnél felvenni?");
                int mennyi = int.Parse(Console.ReadLine());

                for (int i = 0; i < mennyi; i++)
                {
                    Hozzaadas(diakok);
                }
            }
        }

        static void Lekérdezés(List<Felkeszito> diakok)
        {
            foreach(var di in diakok)
            {
                Console.WriteLine(di.Nev);
            }
            Console.Write("Kinek az adatait szeretnéd lekérdezni? ");
            string d = Console.ReadLine();

            foreach (var diak in diakok)
            {
                if (diak.Nev == d)
                {
                    Console.WriteLine($"Név: {diak.Nev}");
                    Console.WriteLine($"Kor: {diak.Kor}");
                    Console.WriteLine($"Nem: {diak.Nem}");
                    Console.WriteLine($"Lakcím: {diak.Lakcim[0]} {diak.Lakcim[1]} {diak.Lakcim[2]}");
                    Console.WriteLine($"Városi / Vidéki: {diak.VaVi}");
                    Console.WriteLine($"Kollégista: {diak.Kolleg}");
                    Console.WriteLine($"Bejárós: {diak.Bejar}");
                    Console.WriteLine($"Személyi szám: {diak.Szemszam}");
                    Console.WriteLine($"Gondviselő: {diak.Gondviselo}");
                    Console.WriteLine($"E-mail: {diak.Email}");
                    Console.WriteLine($"Telefon: {diak.Tel}");
                    Console.WriteLine($"Gondviselő telefon: {diak.GondTel}");
                }
            }
        }

        static void Hozzaadas(List<Felkeszito> diakok)
        {
            string[] t = new string[12];
            Console.Write("Add meg a nevét: ");
            t[0] = Console.ReadLine();
            Console.Write("Add meg a korát: ");
            t[1] = Console.ReadLine();
            Console.Write("Add meg a nemét: ");
            t[2] = Console.ReadLine();
            Console.Write("Add meg a lakcímét a követkető formátumban (irányítószám,település,utca házszám): ");
            t[3] = Console.ReadLine();
            Console.Write("Add meg hogy városi vagy vidéki (Városi/Vidéki): ");
            t[4] = Console.ReadLine();
            Console.Write("Kollégista? (Igen/Nem): ");
            t[5] = Console.ReadLine();
            Console.Write("Bejárós? (Igen/Nem): ");
            t[6] = Console.ReadLine();
            Console.Write("Add meg a személyigazolvány számát: ");
            t[7] = Console.ReadLine();
            Console.Write("Add meg a gondviselője nevét: ");
            t[8] = Console.ReadLine();
            Console.Write("Add meg a e-mail címét: ");
            t[9] = Console.ReadLine();
            Console.Write("Add meg a telefonszámát: ");
            t[10] = Console.ReadLine();
            Console.Write("Add meg a gonviselő telefonszámát: ");
            t[11] = Console.ReadLine();

            diakok.Add(new Felkeszito(t));

            StreamWriter txt = new StreamWriter("Felkészítő.txt", true);
            txt.WriteLine($"{t[0]};{t[1]};{t[2]};{t[3]};{t[4]};{t[5]};{t[6]};{t[7]};{t[8]};{t[9]};{t[10]};{t[11]}");
            txt.Close();
        }
    }
}