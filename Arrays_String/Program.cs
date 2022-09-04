using System;
using System.Threading;

namespace ConsoleApp2__Exam10_
{
    class Program
    {
        static string Exam(string[,]arr, int size, int questionIndex)
        {
            int[] randomAnswer = new int[3];
            int k = 0;
            while (k < 3)
            {
                bool found = false;
                Random random = new Random();
                int number = random.Next(1, 4);
                for (int i = 0; i < k; i++){
                    if (randomAnswer[i] == number)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    randomAnswer[k++] = number;
                }
            }
            bool[] choosenVariant = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(arr[questionIndex, 0]);
                Console.WriteLine("-~-~-~-~-~-~-~-~-");
                for (int i = 0; i < size; i++)
                {
                    if (choosenVariant[i])
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{char.ConvertFromUtf32(65 + i)}) ");
                    Console.WriteLine(arr[questionIndex, randomAnswer[i]]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo Key = Console.ReadKey();
                if(Key.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if(Key.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (Key.Key == ConsoleKey.Enter)
                {
                    return arr[questionIndex,randomAnswer[index]];
                }
                for (int i = 0; i < size; i++)
                {
                    choosenVariant[i] = false;
                }
                choosenVariant[index] = true;
            }
        }
        static void Main(string[] args)
        {
            string[,] questions = new string[10, 4];
            int[] answers = new int[10];
           
            //Ques1
            questions[0, 0] = "Cenubi Koreyanın en böyük texnologiya şirketinin adı nedir?";
            questions[0, 1] = "Samsung";
            questions[0, 2] = "LG";
            questions[0, 3] = "Hundai";
            //Ques2
            questions[1, 0] = "İlk kompüter animasiyalar harada istehsal edildi?";
            questions[1, 1] = "Walt Disney";
            questions[1, 2] = "Rutherford Appleton";
            questions[1, 3] = " Oriental Light and Magic";
            //Ques3
            questions[2, 0] = " Juche qalası haradadır?";
            questions[2, 1] = "Şimali Koreya";
            questions[2, 2] = "Çin";
            questions[2, 3] = "Yaponiya";
            //Ques4
            questions[3, 0] = "Yer üzünde bir insana ne qeder su var?";
            questions[3, 1] = "210,900,000,000 l";
            questions[3, 2] = "293,400,000,000 l";
            questions[3, 3] = "512,100,000,000 l";
            //Ques5
            questions[4, 0] = "James Naismith 1891-ci ilde hansı idman oyununu ixtira etdi?";
            questions[4, 1] = "Futbol";
            questions[4, 2] = "Basketbol";
            questions[4, 3] = "Tennis";
            //Ques6
            questions[5, 0] = "Bir Octopusun neçe üreyi var?";
            questions[5, 1] = "1";
            questions[5, 2] = "2";
            questions[5, 3] = "3";
            //Ques7
            questions[6, 0] = "Dünyanın en kiçik quşu nedir?";
            questions[6, 1] = "Bee Hummingbird";
            questions[6, 2] = "Satanic Nightjar";
            questions[6, 3] = "Lazy Cisticola";
            //Ques8
            questions[7, 0] = "Leonardo da Vinçinin Mona Lizası dünyanın harasında sergilenir?";
            questions[7, 1] = "Luvr, Paris, Fransa";
            questions[7, 2] = "Orse, Paris, Fransa";
            questions[7, 3] = "Val-de-Marn, Paris, Fransa";
            //Ques9
            questions[8, 0] = "Portuqaliyanın paytaxtı haradır?";
            questions[8, 1] = "Porto";
            questions[8, 2] = "Lisbon";
            questions[8, 3] = "Braqa";
            //Ques10
            questions[9, 0] = "Thor çekicinin adı nedir?";
            questions[9, 1] = "Vanir";
            questions[9, 2] = "Mjolnir";
            questions[9, 3] = "Aesir";

            #region Answers
            //Answer1
            answers[0] = 1;
            //Answer2
            answers[1] = 2;
            //Answer3
            answers[2] = 1;
            //Answer4
            answers[3] = 1;
            //Answer5
            answers[4] = 2;
            //Answer6
            answers[5] = 3;
            //Answer7
            answers[6] = 1;
            //Answer8
            answers[7] = 1;
            //Answer9
            answers[8] = 2;
            //Answer10
            answers[9] = 2;
            #endregion

            int[] randomQues = new int[10];
            int score = 0, correct = 0, wrong = 0, k = 0;
            while(k < 10){
                bool found = false;
                Random random = new Random();
                int number = random.Next(0, 10);
                for (int i = 0; i < k; i++){
                    if (randomQues[i] == number)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    randomQues[k++] = number;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                int index = randomQues[i];
                string answer = Exam(questions, 3, index);
                Console.Clear();
                if (answer == questions[index, answers[index]])
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\tCorrect !!!");
                    score += 10;
                    correct++;
                }
                else{
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\tWrong !!!");
                    if (score > 0) score -= 10;
                    wrong++;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Clear();
            Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\tScore: {score} \n\t\t\t\t\t\tCorrect Answers: {correct} \n\t\t\t\t\t\tWrong Answers: {wrong}\n\n\n\n\n\n\n\n");
        }
    }
}