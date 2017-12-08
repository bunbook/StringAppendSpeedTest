using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAppendSpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw3 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw4 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw5 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw6 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw7 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw8 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch sw9 = new System.Diagnostics.Stopwatch();

            Random rand = new Random();

            const int number = 1000000;
            const int length = 36;

            for (int i = 0; i < number; i++)
            {
                // 配列生成
                sw1.Start();
                int[] map = new int[length];
                for (int j = 0; j < length; j++) map[j] = rand.Next(10);
                int val = rand.Next(10000);
                sw1.Stop();

                // str plus
                sw2.Start();
                string str1 = "";
                for (int j = 0; j < length; j++) str1 += map[j].ToString();
                sw2.Stop();

                // SB ToString有
                sw3.Start();
                StringBuilder sb1 = new StringBuilder("");
                for (int j = 0; j < length; j++) sb1.Append(map[j].ToString());
                string str2 = sb1.ToString();
                sw3.Stop();

                // SB ToString無
                sw4.Start();
                StringBuilder sb2 = new StringBuilder("");
                for (int j = 0; j < length; j++) sb2.Append(map[j]);
                string str3 = sb2.ToString();
                sw4.Stop();

                // SB Linq
                sw5.Start();
                string str4 = map.Aggregate(new StringBuilder(), (sb3, s) => sb3.Append(s)).ToString();
                sw5.Stop();

                // str Concat ToString有
                sw6.Start();
                String str5 = "";
                for (int j = 0; j < length; j++) str5 = String.Concat(str5, map[j].ToString());
                sw6.Stop();

                // str Concat ToString無
                sw7.Start();
                string str6 = "";
                for (int j = 0; j < length; j++) str6 = String.Concat(str6, map[j]);
                sw7.Stop();

                // str Concat 一括
                sw8.Start();
                string str7 = String.Concat(map);
                sw8.Stop();

                // str Join 一括
                sw9.Start();
                string str8 = String.Join("", map);
                sw9.Stop();

                if (i != 0) continue;

                Console.WriteLine(str1);
                Console.WriteLine(str2);
                Console.WriteLine(str3);
                Console.WriteLine(str4);
                Console.WriteLine(str5);
                Console.WriteLine(str6);
                Console.WriteLine(str7);
                Console.WriteLine(str8);
            }

            Console.WriteLine("配列生成:              " + sw1.Elapsed);
            Console.WriteLine("str plus:              " + sw2.Elapsed);
            Console.WriteLine("SB ToString有:         " + sw3.Elapsed);
            Console.WriteLine("SB ToString無:         " + sw4.Elapsed);
            Console.WriteLine("SB Linq:               " + sw5.Elapsed);
            Console.WriteLine("str Concat ToString有: " + sw6.Elapsed);
            Console.WriteLine("str Concat ToString無: " + sw7.Elapsed);
            Console.WriteLine("str Concat 一括:       " + sw8.Elapsed);
            Console.WriteLine("str Join 一括:         " + sw9.Elapsed);

            Console.ReadLine();
        }
    }
}
