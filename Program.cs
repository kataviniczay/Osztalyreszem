using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

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

            bool fut = true;
            while(fut = true) {

                Console.WriteLine("Új diákot szeretnél hozzáadni vagy meglévő diákok adatát szeretnéd lekérdezni? (Ha új adat akkor 'new data', ha lekérdezni akkor 'old data')");
                string oldnew = Console.ReadLine();
                if(oldnew == "x")
                {
                    fut = false;
                }

                if (oldnew == "new data")
                {
                    Console.WriteLine("Hány diákot szeretnél felvenni?");
                    int mennyi = int.Parse(Console.ReadLine());

                    for (int i = 0; i < mennyi; i++)
                    {
                        Hozzaadas(diakok);
                    }
                }
                string kod = "";
                if (oldnew == "old data")
                {
                    Console.WriteLine("Választható lekérdezések:\n\t1.Kiírás abc szerinti sorrendben\n\t2.Megadott név adatainak kiírása\n\t3.Megadott életkorú diákok kiírása\n\t4.18 év alatti/feletti diákok kiírása\n\t5.Megadott diák lakcímének kiírása\n\t6.Megadott városban élő diákok kiírása\n\t7.Városi vagy vidéki diákok kiírása\n\t8.Kollégista vagy nem kollégista diákok kiírása\n\t9.Megadott személyiigazolvány-szám alapján minden adat kiírása\n\t10.Megadott gondviselő neve alapján diák/diákok nevének kiírása\n\t11.Megadott gondviselő telefonszáma");
                    Console.Write("Választott lekérdezés száma (pl.: 4): ");
                    kod = Console.ReadLine();
                }

                switch (kod)
                {
                    case "1":
                        Console.WriteLine("\nA diákok nevei abc sorrendben:");
                        L1(diakok);
                        break;
                    case "2":
                        L2(diakok);
                        break;
                    case "3":
                        Console.WriteLine("\nA keresett korú diákok nevei:");
                        L3(diakok);
                        break;
                    case "4":
                        L4(diakok);
                        break;
                    case "5":
                        L5(diakok);
                        break;
                    case "6":
                        L6(diakok);
                        break;
                    case "7":
                        Console.WriteLine("\nA keresett korú diákok nevei:");
                        L7(diakok);
                        break;
                    case "8":
                        L8(diakok);
                        break;
                    case "9":
                        L9(diakok);
                        break;
                    case "10":
                        L10(diakok);
                        break;
                    case "11":
                        L11(diakok);
                        break;

                }

            }

            Console.ReadKey();
        }

        static void L1(List<Felkeszito> diakok)
        {
            List<string> abcNevek = new List<string>();
            foreach(var d in diakok)
            {
                abcNevek.Add(d.Nev);
            }
            abcNevek.Sort();
            for(int i = 0; i < abcNevek.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {abcNevek[i]}");
            }

        }

        static void L2(List<Felkeszito> diakok)
        {
            foreach (var di in diakok)
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
                    Console.WriteLine($"Lakcím: {diak.Lakcime.Iranyitoszam} {diak.Lakcime.Varos} {diak.Lakcime.UtcaHazszam}");
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

        static void L3(List<Felkeszito> diakok)
        {
            Console.Write("Keresett kor: ");
            int kor = int.Parse(Console.ReadLine());

            bool van = false;
            foreach(var d in diakok)
            {
                if(d.Kor == kor)
                {
                    Console.WriteLine(d.Nev);
                    van = true;
                }
            }
            if (!van)
            {
                Console.WriteLine("Nincs ilyen korú diák.");
            }
        }

        static void L4(List<Felkeszito> diakok)
        {
            Console.WriteLine("18 év alatti diákok:");
            foreach(var d in diakok)
            {
                Console.Write(d.Nev + ", ");
            }

            Console.WriteLine("\n\n18 év feletti diákok:");
            foreach (var d in diakok)
            {
                Console.Write(d.Nev + ", ");
            }
        }

        static void L5(List<Felkeszito> diakok) {
            Console.Write("Keresett diák neve: ");
            string nev = Console.ReadLine();
            bool van = false;

            foreach (var d in diakok)
            {
                if(d.Nev == nev)
                {
                    Console.WriteLine($"A keresett diák lakcíme: {d.Lakcime.Iranyitoszam} {d.Lakcime.Varos} {d.Lakcime.UtcaHazszam}");
                    van = true;
                }
            }
            if (!van)
            {
                Console.WriteLine("Nem található ilyen nevű diák.");
            }
        }

        static void L6(List<Felkeszito> diakok)
        {
            Console.Write("Város: ");
            string varos = Console.ReadLine();
            Console.WriteLine("A keresett városból származó diákok: ");
            foreach(var d in diakok)
            {
                if(d.Lakcime.Varos == varos)
                {
                    Console.WriteLine(d.Nev);
                }
            }
        }

        static void L7(List<Felkeszito> diakok)
        {
            Console.Write("Városi vagy vidéki? (v/vi): ");
            string valasz = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("\nA keresett kategóriába tartozó diákok:");

            foreach (var d in diakok)
            {
                bool varosi = d.VaVi.ToLower() == "városi";
                bool videki = d.VaVi.ToLower() == "vidéki";

                if ((valasz == "v" && varosi) ||
                    (valasz == "vi" && videki))
                {
                    Console.WriteLine(d.Nev);
                }
            }
        }

        static void L8(List<Felkeszito> diakok)
        {
            Console.Write("Kollégista? (i/n): ");
            string valasz = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("\nA keresett diákok:");

            foreach (var d in diakok)
            {
                bool kollegista = d.Kolleg.ToLower() == "igen";
                bool nemKollegista = d.Kolleg.ToLower() == "nem";

                if ((valasz == "i" && kollegista) || (valasz == "n" && nemKollegista))
                {
                    Console.WriteLine(d.Nev);
                }
            }
        }

        static void L9(List<Felkeszito> diakok)
        {
            Console.Write("Add meg a személyi igazolvány számot: ");
            string sz = Console.ReadLine().Trim();

            Felkeszito talalt = null;

            foreach (var d in diakok)
            {
                if (d.Szemszam == sz)
                {
                    talalt = d;
                    break;
                }
            }

            if (talalt == null)
            {
                Console.WriteLine("Nincs ilyen diák.");
                return;
            }

            Console.WriteLine($"\nNév: {talalt.Nev}");
            Console.WriteLine($"Kor: {talalt.Kor}");
            Console.WriteLine($"Nem: {talalt.Nem}");
            Console.WriteLine($"Lakhely: {talalt.Lakcime.Iranyitoszam} {talalt.Lakcime.Varos}, {talalt.Lakcime.UtcaHazszam}");
            Console.WriteLine($"VáVi: {talalt.VaVi}");
            Console.WriteLine($"Kollégista: {talalt.Kolleg}");
            Console.WriteLine($"Bejáró: {talalt.Bejar}");
            Console.WriteLine($"Személyi szám: {talalt.Szemszam}");
            Console.WriteLine($"Gondviselő: {talalt.Gondviselo}");
            Console.WriteLine($"Email: {talalt.Email}");
            Console.WriteLine($"Tel: {talalt.Tel}");
            Console.WriteLine($"Gondviselő tel.: {talalt.GondTel}");
        }

        static void L10(List<Felkeszito> diakok)
        {
            Console.Write("Gondviselő neve: ");
            string nev = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("\nA gondviselőhöz tartozó diákok:");

            bool talalt = false;

            foreach (var d in diakok)
            {
                if (d.Gondviselo.ToLower() == nev)
                {
                    Console.WriteLine(d.Nev);
                    talalt = true;
                }
            }

            if (!talalt)
            {
                Console.WriteLine("Nincs ilyen gondviselő.");
            }
        }

        static void L11(List<Felkeszito> diakok)
        {
            Console.Write("Gondviselő neve: ");
            string nev = Console.ReadLine().Trim().ToLower();

            bool talalt = false;

            foreach (var d in diakok)
            {
                if (d.Gondviselo.ToLower() == nev)
                {
                    Console.WriteLine($"{d.Nev} gondviselőjének telefonszáma: {d.GondTel}");
                    talalt = true;
                }
            }

            if (!talalt)
            {
                Console.WriteLine("Nincs ilyen gondviselő a listában.");
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
            txt.WriteLine($"\b{t[0]};{t[1]};{t[2]};{t[3]};{t[4]};{t[5]};{t[6]};{t[7]};{t[8]};{t[9]};{t[10]};{t[11]}");
            txt.Close();
        }
    }
}
