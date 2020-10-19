using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace LinqExcercise
{   
   class Person
    {
        public string Namn;
        public DateTime Nameday;

        public Person(string n, string d)
        {
            Namn = n;
            Nameday = DateTime.Parse(d);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> elenco = new List<Person>();                                                            //Console.WriteLine ( File.ReadAllText("names.csv"));


            string testo = File.ReadAllText("names.txt");

             string[] ts = testo.Split("\n");                                  // string[] ts = File.ReadLines("names.txt");


            //foreach(string riga in ts)
            for (int i = 0; i < ts.Length - 1; i++)
            {
                string[] td = ts[i].Split(";");

                                                     //Console.WriteLine($" {td[0]} - {td[1]}");

                Person p = new Person(td[0], td[1]);

                if (controlla(td[0], elenco) == false)

                elenco.Add(p);

            }
            //// Person p;                                                       //controllaZ("" , elenco);
            ////  var q = from p in elenco
            ////     where p.Namn == "Zlatan" select p.Namn;

            //foreach (Person x in elenco)
            //    Console.WriteLine($"{x.Namn} - {x.Nameday}");

            //namsDag("and", elenco);
           
            var q2a = from p in elenco where p.Namn.StartsWith("And") select p.Namn;

            var q2b = from p in elenco where p.Nameday.Month == 6 && p.Nameday.Day == 22 select p.Namn;

            var q2c = from p in elenco where p.Namn.StartsWith("P") && p.Nameday.Month == 4 select p.Namn;

            //var qx1 = q2a.Take(10);

            Console.Write(" Insert name ");

            string nome = Console.ReadLine();

            if (nome.Length > 0)
            {

                var q3 = from p in elenco where p.Namn == nome select p.Namn;

                foreach (string s in q3)
                    Console.WriteLine(s);
            }
            //_______________________________________________________________________________________________________________

            //  4.        
            Console.Write(" insert date ");

            string data = Console.ReadLine();

            if (data.Length > 6)
            {
                int day = DateTime.Parse(data).Day;
                int month = DateTime.Parse(data).Month;
                Console.WriteLine($" month {month} day {day}");
                var q4 = from p in elenco where (p.Nameday.Day == day) && (p.Nameday.Month == month) select p.Namn;

                foreach (string s in q4)
                    Console.WriteLine(s);

            }
            //_______________________________________________________________________________________________________________  

           //  var x = "Ivan";
          //  Console.WriteLine(x.Substring(2, 1));     //   substring(2,1)   2= position , 1 = quantity of character    



            //var q5 = from p in elenco group p by p.Namn.Substring(0, 1);    // 

            //foreach(var x in q5)
            //{
            //    Console.WriteLine("_______________" + x.Count());

            //    foreach (var y in x)
            //    {
            //        Console.WriteLine(y.Namn);
            //    }

            //}
            //_______________________________________________________________________________________________________________
           
            var q6a = from p in elenco group p by p.Nameday.Month;

            foreach (var z in q6a)
                Console.WriteLine(z.Count());


            //______________________________________________________________________________________________


            var q6b = from p in elenco group p by p.Nameday.Month;

            int c = 1;
            int[] mon = new int[13];

            foreach (var k in q6b)
                mon[c++] = k.Count();                                //Console.WriteLine(k.Count());

            Console.WriteLine($" 1 kvartal {mon[1] + mon[2] + mon[3] }   ");
            Console.WriteLine($" 2 kvartal {mon[4] + mon[5] + mon[6] }   ");
            Console.WriteLine($" 3 kvartal {mon[7] + mon[8] + mon[9] }   ");
            Console.WriteLine($" 4 kvartal {mon[10] + mon[11] + mon[12] }   ");

            Console.WriteLine("___________________________________");

            //_____________________________________________________________________________________________


            var q6c = from p in elenco group p by p.Nameday.DayOfYear;   

            var q6c1 = from p in q6c orderby p.Count()descending select p.Count();
            var q6c2 = q6c1.Take(5);

                                                //foreach (var s in q6c)
                                               //    Console.Write(s.Count() + " ");


                                               //foreach (var s in q6c1)
                                              //    Console.Write(s + "  ");


            foreach (var s in q6c2)
                Console.WriteLine(s);

        }

        //static void namsDag(string nome1, List<Person> p3) {

        //     nome1 = "And";

        //    foreach (Person nmdata in p3)
        //    {

        //        if (nmdata.Namn.StartsWith(nome1))                    // if (nmdatStartsWith("nome1"))

        //            Console.WriteLine(nmdata.Namn);
        //}
        //    }

        static bool controlla(string nome, List<Person> p2)

        { foreach (Person n in p2)
            {
                if (n.Namn == nome)
                    return true;
            }
            return false;
        }

        //static bool controllaZ(string nome, List<Person> p2)

        //{
        //     nome = "Zlatan"; 

        //    foreach (Person n in p2)
        //    {
        //        if (n.Namn == nome)
        //            Console.WriteLine(nome);
        //    }
        //    return false;
        //}
    }
}
