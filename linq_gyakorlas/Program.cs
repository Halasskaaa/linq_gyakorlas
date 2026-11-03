using System.Collections.Concurrent;
using System.Globalization;

namespace linq_gyakorlas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //List<int> szamok = new List<int> { 4, 12, 7, 28, 42, 18, 3, 25, 6 };

        //LINQ nélkkül
            //List<int> eredmeny = new List<int>();

            //foreach (int szam in szamok) 
            //{
            //    if (szam>10)
            //    {
            //        eredmeny.Add(szam);
            //    }
            //}

        //LINQ-val 1
            //var eredmeny = szamok.Where(szam => szam > 10);

        //2
            //int[] szamok = { 4, 12, 7, 28, 42, 18, 3, 25, 6 };
        //3
            //var eredmeny = szamok.
            //    Where(szam => szam > 10)
            //    .OrderBy(szam => szam);
        //4
            //var eredmeny = from szam in szamok
            //               where szam > 10
            //               orderby szam
            //               select szam;

            //foreach (int szam in eredmeny)
            //{
            //    Console.WriteLine(szam);
            //}

            List<Diak> diakok = File.ReadAllLines("diakok.csv")
                .Skip(1)
                .Select(sor =>
                {
                    string[] adatok = sor.Split(';');

                    return new Diak(
                        adatok[0],
                        int.Parse(adatok[1]),
                        adatok[2],
                        double.Parse(adatok[3], CultureInfo.GetCultureInfo("hu-HU"))
                    );
                })
                .ToList();

            //var eredmeny = diakok.Where(d => d.Eletkor >= 18 && d.Atlag >= 4.0);
            //var eredmeny = diakok.Where(d => d.Osztaly == "11A" || d.Osztaly == "13A");
            //var eredmeny = diakok.Where(d => d.Osztaly != "12B");
            //var eredmeny = diakok.Where(d => !(d.Osztaly == "12B"));

            //foreach (Diak d in eredmeny)
            //{
            //    Console.WriteLine($"{d.Nev} ({d.Eletkor}) - {d.Osztaly} - {d.Atlag}");
            //}

            //foreach (Diak d in diakok)
            //{
            //    Console.WriteLine($"{d.Nev} ({d.Eletkor}) - {d.Osztaly} - {d.Atlag}");
            //}


            //var nevek = diakok.Select(d => d.Nev);

            //foreach (string nev in nevek)
            //{
            //    Console.WriteLine(nev);
            //}


            //var eletkorok = diakok.Select(d => d.Eletkor*2);

            //foreach (int eletkor in eletkorok)
            //{
            //    Console.WriteLine(eletkor);
            //}


            //var adatok = diakok.Select(d => new
            //{
            //    d.Nev,
            //    d.Osztaly
            //});

            //foreach (var adat in adatok)
            //{
            //    Console.WriteLine($"{adat.Nev} - {adat.Osztaly}");
            //}


            //    var sorok = diakok.Select(d => $"{d.Nev} - {d.Osztaly}");

            //    foreach (string sor in sorok)
            //    {
            //        Console.WriteLine(sor);
            //    }


            //var nevek = diakok
            //    .Where(d => d.Atlag >= 4.0)
            //    .Select(d => d.Nev);

            //foreach (string nev in nevek)
            //{
            //    Console.WriteLine(nev);
            //}


            //var eredmeny = diakok.OrderBy(d => d.Eletkor);

            //foreach(Diak d in eredmeny)
            //{
            //    Console.WriteLine($"{d.Nev} - {d.Eletkor}");
            //}


            //var eredmeny = diakok.OrderByDescending(d => d.Atlag);

            //foreach (Diak d in eredmeny)
            //{
            //    Console.WriteLine($"{d.Nev} - {d.Atlag}");
            //}


            //var eredmeny = diakok
            //    .OrderBy(d => d.Osztaly)
            //    .ThenByDescending(d => d.Atlag);

            //foreach (Diak d in eredmeny)
            //{
            //    Console.WriteLine($"{d.Nev} - {d.Osztaly} - {d.Atlag}");
            //}


            //var eredmeny = diakok.OrderBy(d => d.Nev);

            //foreach (Diak d in eredmeny)
            //{
            //    Console.WriteLine($"{d.Nev} - {d.Osztaly} - {d.Atlag}");
            //}

            var eredmeny = diakok
                .OrderByDescending(d => d.Atlag)
                .Take(3); //limit

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev} - {d.Osztaly} - {d.Atlag}");
            }
        }
    }
}
