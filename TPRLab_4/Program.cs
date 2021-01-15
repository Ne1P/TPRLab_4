using System;
using System.Linq;
using System.Text;

namespace TPRLab_4
{
    class Expert
    {
        public string name;
        public string[] objName = new string[6];
        public int[] preferences = new int[6];
        public double[] coefficients = new double[5];
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            double[,] input=Data.ReadInput();

            Expert expert1 = new Expert();
            expert1.name = "Експерт 1 (збалансованість)";
            expert1.objName[0] = "Gigabyte GTX 1070";
            expert1.objName[1] = "Gigabyte RX 580";
            expert1.objName[2] = "Gigabyte GTX 1070 TI";
            expert1.objName[3] = "Gigabyte RTX 2060";
            expert1.objName[4] = "Gigabyte GTX 1660 S";
            expert1.objName[5] = "Gigabyte RX 5500";

            expert1.preferences[0] = 6;
            expert1.preferences[1] = 7;
            expert1.preferences[2] = 8;
            expert1.preferences[3] = 8;
            expert1.preferences[4] = 6;
            expert1.preferences[5] = 7;

            expert1.coefficients[0] = 0.25;
            expert1.coefficients[1] = 0.3;
            expert1.coefficients[2] = 0.15;
            expert1.coefficients[3] = 0.2;
            expert1.coefficients[4] = 0.1;

            Expert expert2 = new Expert();
            expert2.name = "Експерт 2 (новизна)";
            expert2.objName[0] = "Gigabyte GTX 1070";
            expert2.objName[1] = "Gigabyte RX 580";
            expert2.objName[2] = "Gigabyte GTX 1070 TI";
            expert2.objName[3] = "Gigabyte RTX 2060";
            expert2.objName[4] = "Gigabyte GTX 1660 S";
            expert2.objName[5] = "Gigabyte RX 5500";

            expert2.preferences[0] = 5;
            expert2.preferences[1] = 9;
            expert2.preferences[2] = 8;
            expert2.preferences[3] = 9;
            expert2.preferences[4] = 8;
            expert2.preferences[5] = 6;

            expert2.coefficients[0] = 0.1;
            expert1.coefficients[1] = 0.15;
            expert2.coefficients[2] = 0.3;
            expert2.coefficients[3] = 0.3;
            expert2.coefficients[4] = 0.15;

            Expert expert3 = new Expert();
            expert3.name = "Експерт 3 (практичність)";
            expert3.objName[0] = "Gigabyte GTX 1070";
            expert3.objName[1] = "Gigabyte RX 580";
            expert3.objName[2] = "Gigabyte GTX 1070 TI";
            expert3.objName[3] = "Gigabyte RTX 2060";
            expert3.objName[4] = "Gigabyte GTX 1660 S";
            expert3.objName[5] = "Gigabyte RX 5500";

            expert3.preferences[0] = 7;
            expert3.preferences[1] = 9;
            expert3.preferences[2] = 8;
            expert3.preferences[3] = 6;
            expert3.preferences[4] = 8;
            expert3.preferences[5] = 8;

            expert3.coefficients[0] = 0.3;
            expert3.coefficients[1] = 0.2;
            expert3.coefficients[2] = 0.15;
            expert3.coefficients[3] = 0.15;
            expert3.coefficients[4] = 0.2;

            double[] expert1res = new double[6];
            double[] expert2res = new double[6];
            double[] expert3res = new double[6];

            expert1res = findResultOneExpert(expert1, input);
            expert2res = findResultOneExpert(expert2, input);
            expert3res = findResultOneExpert(expert3, input);

            Console.WriteLine();
            Console.WriteLine();

            //for (int i = 0; i < expert1res.Length; i++)
            //{
            //    Console.Write(expert1res[i] + "   ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < expert2res.Length; i++)
            //{
            //    Console.Write(expert2res[i] + "   ");
            //}
            //Console.WriteLine();
            //for (int i = 0; i < expert3res.Length; i++)
            //{
            //    Console.Write(expert3res[i] + "   ");
            //}
            //Console.WriteLine();

            printExpertRes(expert1, input, expert1res);
            printExpertRes(expert2, input, expert2res);
            printExpertRes(expert3, input, expert3res);

            double[] averageRes = new double[6];

            for (int j = 0; j < averageRes.Length; j++)
            {
                averageRes[j] = (expert1res[j] + expert2res[j] + expert3res[j]) / 3;
            }

            for (int z = 0; z < expert1.objName.Length ; z++)
            {
                Console.WriteLine("Середнє значення для "+expert1.objName[z] + "      " + averageRes[z]);
            }
            Console.WriteLine();
            double maxVal = averageRes.Max();
            int bestResIndx = Array.IndexOf(averageRes, maxVal);

            Console.WriteLine("Найкраще рышення: " + expert1.objName[bestResIndx] + "      " + averageRes[bestResIndx]);


            Console.ReadKey();
        }
        public static void printExpertRes(Expert expert, double[,] input, double[] results)
        {
            string[] parameters = new string[5];
            parameters[0] = "Вартість (1-10)";
            parameters[1] = "Пот. процесів(1-10)";
            parameters[2] = "Об’єм пам’яті (Гб)";
            parameters[3] = "Частота ГП (1-10)";
            parameters[4] = "Особ. вподоб.(1 - 10)";

            Console.WriteLine(expert.name);
            Console.WriteLine("№    " + "Параметр               " + "Вага     " + "А        " + "Б        " + "В        " + "Г        " + "Д        " + "Е");
            for (int i = 0; i < expert.coefficients.Length; i++)
            {
                if(i<4)
                    Console.WriteLine((i+1)+"   "+parameters[i]+"       "+"|"+ expert.coefficients[i]+"     "+"|"+input[i,0]+"      " + "|" + input[i, 1] + "      " + "|" + input[i, 2] + "      " + "|" + input[i, 3] + "      " + "|" + input[i, 4] + "      " + "|" + input[i, 5]);
                else
                    Console.WriteLine((i + 1) + "   " + parameters[i] + "       " + "|" + expert.coefficients[i] + "     " + "|" + expert.preferences[0] + "      " + "|" + expert.preferences[1] + "      " + "|" + expert.preferences[2] + "      " + "|" + expert.preferences[3] + "      " + "|" + expert.preferences[4] + "      " + "|" + expert.preferences[5]);
            }
            Console.WriteLine("Сума                          1       " + "|" + results[0]+ "     " + "|" + results[1] + "     " + "|" + results[2] + "     " + "|" + results[3] + "     " + "|" + results[4] + "     " + "|" + results[5]);
            Console.WriteLine();
        }
        public static double[] findResultOneExpert(Expert expert, double[,] data)
        {
            double[] results = new double[6];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = expert.coefficients[0] * data[0, i] + expert.coefficients[1] * data[1, i] + expert.coefficients[2] * data[2, i] + expert.coefficients[3] * data[3, i] + expert.coefficients[4] * expert.preferences[i];
            }

            return results;
        }
    }
}
