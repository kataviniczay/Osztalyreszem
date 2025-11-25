using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Projektkonzol
{
    public class Hiba : Exception
    {
        public Hiba(string message) : base(message)
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Felkeszito> diakok = new List<Felkeszito>();

            foreach (var d in File.ReadAllLines("Felkeszito.txt"))
            {
                string[] temp = d.Split(';');

                diakok.Add(new Felkeszito(temp));
            }


            Console.WriteLine("              _       _    __     _        __ _       _     __                  _       _   _      _     __         _           __      \n     /\\      | |     | |  / _|   | |      /_/| |     | |   /_/                 | |     | | | |    | |   /_/        | |         /_/      \n    /  \\   __| | __ _| |_| |_ ___| |_   _____| |_ ___| |   ___  ___    __ _  __| | __ _| |_| | ___| | _____ _ __ __| | ___ _______  ___ \n   / /\\ \\ / _` |/ _` | __|  _/ _ \\ \\ \\ / / _ \\ __/ _ \\ |  / _ \\/ __|  / _` |/ _` |/ _` | __| |/ _ \\ |/ / _ \\ '__/ _` |/ _ \\_  / _ \\/ __|\n  / ____ \\ (_| | (_| | |_| ||  __/ |\\ V /  __/ ||  __/ | |  __/\\__ \\ | (_| | (_| | (_| | |_| |  __/   <  __/ | | (_| |  __// /  __/\\__ \\\n /_/    \\_\\__,_|\\__,_|\\__|_| \\___|_| \\_/ \\___|\\__\\___|_|  \\___||___/  \\__,_|\\__,_|\\__,_|\\__|_|\\___|_|\\_\\___|_|  \\__,_|\\___/___\\___||___/\n                                                                                                                                        \n                                                                                                                                        ");
            Console.WriteLine("Ez a Felkészítő iskola adatfelvevő és -lekérdező programja. A diákok adatai a 'Felkeszito.txt' fájlban vannak eltárolva, új diák felvétele esetén a fájlhoz hozzáadódnak a felvett adatok. Új adatot a 'felvétel' beírásával, adatot lekérdezni a 'lekérdezés' beírásával tudsz. A felvételnél figyelj a formátumokra! A lekérdezésnél a felsorolt lehetőségek közül tudsz választani, a választott opció sorszámát ('.' nélkül) tudod beírni a lekérdezéshez.");
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");

            bool fut = true;
            while (fut == true)
            {

                Console.WriteLine("Új diákot szeretnél hozzáadni vagy meglévő diákok adatát szeretnéd lekérdezni? (felvétel/lekérdezés)");
                string oldnew = Console.ReadLine();

                if (oldnew == "x")
                {
                    Console.WriteLine("\n       _____                                              __            \n      |  __ \\                                            /_/            \n      | |__) | __ ___   __ _ _ __ __ _ _ __ ___   __   _____  __ _  ___ \n      |  ___/ '__/ _ \\ / _` | '__/ _` | '_ ` _ \\  \\ \\ / / _ \\/ _` |/ _ \\\n      | |   | | | (_) | (_| | | | (_| | | | | | |  \\ V /  __/ (_| |  __/\n      |_|   |_|  \\___/ \\__, |_|  \\__,_|_| |_| |_|   \\_/ \\___|\\__, |\\___|\n                        __/ |                                 __/ |     \n                       |___/                                 |___/      \n ");
                    fut = false;
                }

                if (oldnew == "felvétel")
                {
                    Console.WriteLine("Hány diákot szeretnél felvenni?");
                    int mennyi;

                    try
                    {
                        mennyi = int.Parse(Console.ReadLine());

                        if (mennyi < 1)
                        {
                            Console.WriteLine("A számnak legalább 1-nek kell lennie!");
                            mennyi = 0;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hibás bemenet! Számot kell megadni.");
                        mennyi = 0;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("A megadott szám túl nagy vagy túl kicsi!");
                        mennyi = 0;
                    }



                    for (int i = 0; i < mennyi; i++)
                    {
                        Hozzaadas(diakok);
                    }
                }
                string kod = "";
                if (oldnew == "lekérdezés")
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Választható lekérdezések:\n\t1.Kiírás abc szerinti sorrendben\n\t2.Bekért név adatainak kiírása\n\t3.Bekért életkorú diákok kiírása\n\t4.18 év alatti/feletti diákok kiírása\n\t5.Bekért diák lakcímének kiírása\n\t6.Bekért városban élő diákok kiírása\n\t7.Városi vagy vidéki diákok kiírása\n\t8.Kollégista vagy nem kollégista diákok kiírása\n\t9.Bekért személyi igazolvány szám alapján minden adat kiírása\n\t10.Bekért gondviselő neve alapján diák/diákok nevének kiírása\n\t11.Bekért gondviselő telefonszámának kiírása");

                    Console.WriteLine("\n-------------------------------------------------------------------------------------------------\n");
                    Console.Write("Választott lekérdezés száma (pl.: 4): ");
                    kod = Console.ReadLine();
                }

                switch (kod)
                {
                    case "1":
                        Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("A diákok nevei abc sorrendben:");
                        L1(diakok);
                        break;
                    case "2":
                        Console.WriteLine("A diákok nevei:");
                        L2(diakok);
                        break;
                    case "3":
                        Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
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
            foreach (var d in diakok)
            {
                abcNevek.Add(d.Nev);
            }
            abcNevek.Sort();
            for (int i = 0; i < abcNevek.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {abcNevek[i]}");
            }

        }

        static void L2(List<Felkeszito> diakok)
        {
            bool talalt = false;
            foreach (var di in diakok)
            {
                Console.WriteLine(di.Nev);
            }
            Console.Write("Kinek az adatait szeretnéd lekérdezni? ");
            string d = Console.ReadLine();

            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");


            foreach (var diak in diakok)
            {
                if (diak.Nev == d)
                {
                    talalt = true;
                    Console.WriteLine(d + " adatai:");
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
            if (!talalt)
            {
                Console.WriteLine("Nem található ilyen nevű diák.");
            }
        }

        static void L3(List<Felkeszito> diakok)
        {
            Console.Write("Keresett kor: ");
            int kor;
            try
            {
                kor = int.Parse(Console.ReadLine());
                if (kor < 14 || kor > 18)
                {
                    Console.WriteLine("Hibás kor! ");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hibás bemenet! Számot kell megadni.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("A megadott szám túl nagy vagy túl kicsi!");
                return;
            }
            bool van = false;
            Console.WriteLine("A keresett korú diákok nevei:");
            foreach (var d in diakok)
            {
                if (d.Kor == kor)
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
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("18 év alatti diákok:");
            foreach (var d in diakok)
            {
                if (d.Kor < 18)
                {
                    Console.Write(d.Nev + ", ");
                }

            }

            Console.WriteLine("\n-------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("\n\n18 év feletti diákok:");
            foreach (var d in diakok)
            {
                if (d.Kor >= 18)
                {
                    Console.Write(d.Nev + ", ");
                }

            }
        }

        static void L5(List<Felkeszito> diakok)
        {
            Console.Write("Keresett diák neve: ");
            string nev = Console.ReadLine();
            bool van = false;

            foreach (var d in diakok)
            {
                if (d.Nev == nev)
                {
                    Console.WriteLine($"A keresett diák lakcíme: {d.Lakcime.Iranyitoszam} {d.Lakcime.Varos} {d.Lakcime.UtcaHazszam}");
                    van = true;
                }
            }
            if (!van)
            {
                Console.WriteLine("Nem található ilyen nevű diák.");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
        }

        static void L6(List<Felkeszito> diakok)
        {
            Console.Write("Város: ");
            string varos = Console.ReadLine();
            bool van = false;

            Console.WriteLine("A keresett városból származó diákok: ");
            foreach (var d in diakok)
            {
                if (d.Lakcime.Varos == varos)
                {
                    Console.WriteLine(d.Nev);
                    van = true;
                }
            }
            if (!van)
            {
                Console.WriteLine("Nincs ilyen város az adatbázisban!");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------\n");
        }

        static void L7(List<Felkeszito> diakok)
        {
            Console.Write("Városi (v) vagy vidéki (vi)?: ");
            string valasz = Console.ReadLine().Trim().ToLower();

            if (valasz != "v" && valasz != "vi")
            {
                Console.WriteLine("Nem megfelelő karaktereket adtál meg!");
                return;
            }
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("A keresett kategóriába tartozó diákok:\n");

            foreach (var d in diakok)
            {
                if ((valasz == "v" && d.VaVi.ToLower() == "városi") || (valasz == "vi" && d.VaVi.ToLower() == "vidéki"))
                {
                    Console.WriteLine(d.Nev);
                }
            }
        }

        static void L8(List<Felkeszito> diakok)
        {
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.Write("\nKollégista? (i/n): ");
            string valasz = Console.ReadLine().Trim().ToLower();

            if (valasz != "i" && valasz != "n")
            {
                Console.WriteLine("Nem megfelelő karaktereket adtál meg!");
                return;
            }

            Console.WriteLine("\nA keresett diákok:");

            foreach (var d in diakok)
            {
                if ((valasz == "i" && d.Kolleg.ToLower() == "igen") || (valasz == "n" && d.Kolleg.ToLower() == "nem"))
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
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Személyi igazolvány számhoz tartozó adatok:");

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


            Console.WriteLine("A gondviselőhöz tartozó diákok:");

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
            Console.WriteLine("\n-------------------------------------------------------------------------------------------------\n");
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
            Console.WriteLine("\n\n-------------------------------------------------------------------------------------------------\n");
        }


        static void Hozzaadas(List<Felkeszito> diakok)
        {
            string[] t = new string[12];
            Console.Write("Add meg a nevét: ");
            t[0] = Console.ReadLine();
            if (!Regex.IsMatch(t[0], @"^[A-Za-zÁÉÍÓÖŐÚÜŰáéíóöőúüű ]+$"))
            {
                Console.WriteLine("A név formátuma hibás!");
                return;
            }

            Console.Write("Add meg a korát: ");
            int kor;
            try
            {
                kor = int.Parse(Console.ReadLine());
                if (kor < 14 || kor > 18)
                {
                    Console.WriteLine("Hibás kor! Az életkor nem lehet kisebb, mint 14 és nagyobb, mint 18.");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hibás bemenet! Számot kell megadni.");
                return;
            }

            t[1] = kor.ToString();

            Console.Write("Add meg a nemét: ");
            t[2] = Console.ReadLine();

            Console.Write("Add meg a lakcímét a következő formátumban (irányítószám,település,utca házszám): ");
            t[3] = Console.ReadLine();

            Console.Write("Add meg hogy városi vagy vidéki (Városi/Vidéki): ");
            t[4] = Console.ReadLine();

            if (t[4] != "Városi" && t[4] != "Vidéki")
            {
                Console.WriteLine("Csak 'Városi' vagy 'Vidéki' írható be.");
                return;
            }

            Console.Write("Kollégista? (Igen/Nem): ");
            t[5] = Console.ReadLine();

            if (t[5] != "Igen" && t[5] != "Nem")
            {
                Console.WriteLine("Csak 'Igen' vagy 'Nem' írható be.");
                return;
            }

            Console.Write("Bejárós? (Igen/Nem): ");
            t[6] = Console.ReadLine();

            if (t[6] != "Igen" && t[6] != "Nem")
            {
                Console.WriteLine("Csak 'Igen' vagy 'Nem' írható be.");
                return;
            }

            Console.Write("Add meg a személyigazolvány számát: ");
            t[7] = Console.ReadLine();

            Console.Write("Add meg a gondviselője nevét: ");
            t[8] = Console.ReadLine();

            if (!Regex.IsMatch(t[8], @"^[A-Za-zÁÉÍÓÖŐÚÜŰáéíóöőúüű ]+$"))
            {
                Console.WriteLine("A név csak betűt és szóközt tartalmazhat!");
                return;
            }

            Console.Write("Add meg az e-mail címét: ");
            t[9] = Console.ReadLine();
            Console.Write("Add meg a telefonszámát: ");
            t[10] = Console.ReadLine();
            Console.Write("Add meg a gondviselő telefonszámát: ");
            t[11] = Console.ReadLine();

            if (t[10] == t[11])
            {
                Console.WriteLine("Nem lehet ugyan az a diák és a gondviselő telefonszáma.");
                return;
            }

            diakok.Add(new Felkeszito(t));

            StreamWriter txt = new StreamWriter("Felkeszito.txt", true);
            txt.WriteLine($"\b{t[0]};{t[1]};{t[2]};{t[3]};{t[4]};{t[5]};{t[6]};{t[7]};{t[8]};{t[9]};{t[10]};{t[11]}");
            txt.Close();
        }
    }
}
