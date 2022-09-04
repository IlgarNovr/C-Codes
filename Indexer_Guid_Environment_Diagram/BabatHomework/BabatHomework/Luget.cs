/*
//EXERCISE 1
//1. Indexerin köməyi ilə, Lüğət tərtib edin. Sözü yazanda, sözün mənası ekrana çıxsın. 30-40 söz bəsdir.
*/

using System;

namespace BabatHomework
{
    class Node
    {
        public string Key { get; set; }

        public string Data { get; set; }

        public Node(string key, string data)
        {
            Key = key;
            Data = data;
        }

        public Node()
        {
        }
    }

    class Dictionary
    {
        private Node[] words;
        private int size;


        public string this[string key]
        {
            get
            {
                foreach (var word in words)
                {
                    if (word.Key == key.ToLower())
                        return word.Data;
                }
                throw new Exception("Word is not found");
            }
            set
            {
                Array.Resize<Node>(ref words, ++size);
                words[size - 1] = new Node(key.ToLower(), value.ToLower());
            }
        }

        public Dictionary()
        {
            words = new Node[0];
            size = 0;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary dict = new Dictionary();
            dict["consider"] = "deem to be";
            dict["minute"] = "infinitely or immeasurably small";
            dict["accord"] = "concurrence of opinion";
            dict["evident"] = "clearly revealed to the mind or the senses or judgment";
            dict["practice"] = "a customary way of operation or behavior";
            dict["intend"] = "have in mind as a purpose";
            dict["concern"] = "something that interests you because it is important";
            dict["commit"] = "perform an act, usually with a negative connotation";
            dict["issue"] = "some situation or event that is thought about";
            dict["approach"] = "move towards";
            dict["establish"] = "set up or found";
            dict["utter"] = "without qualification";
            dict["conduct"] = "direct the course of; manage or control";
            dict["engage"] = "consume all of one's attention or time";
            dict["obtain"] = "come into possession of";
            dict["scarce"] = "deficient in quantity or number compared with the demand";
            dict["policy"] = "a plan of action adopted by an individual or social group";
            dict["straight"] = "successive, without a break";
            dict["stock"] = "capital raised by a corporation through the issue of shares";
            dict["apparent"] = "clearly revealed to the mind or the senses or judgment";
            dict["property"] = "a basic or essential attribute shared by members of a class";
            dict["fancy"] = "imagine; conceive of; see in one's mind";
            dict["concept"] = "an abstract or general idea inferred from specific instances";
            dict["court"] = "an assembly to conduct judicial business";
            dict["appoint"] = "assign a duty, responsibility, or obligation to";
            dict["passage"] = "a section of text, particularly a section of medium length";
            dict["vain"] = "unproductive of success";
            dict["instance"] = "an occurrence of something";
            dict["coast"] = "the shore of a sea or ocean";
            dict["project"] = "a planned undertaking";

            while (true)
            {
                Console.Clear();
                Console.Write("Word: ");
                string word = Console.ReadLine();
                try
                {
                    Console.WriteLine(dict[word]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\nPress Enter");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }
        }
    }
}
