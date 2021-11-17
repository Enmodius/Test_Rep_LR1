using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Проверка корректности введенного слова
            bool CheckName(string text)
            {
                string rgx = "(?<!\\S)[a-zA-Zа-яёА-ЯЁ]+(?!\\S)";

                if (Regex.IsMatch(text, rgx))
                {
                    return true;
                }


                else { return false; }
            }

            string word;
            string wordWithMaxLength = string.Empty;
            var wordsList = new List<string>();
            int MaxLength=0;

            char[] spacesToTrim = { '	', ' ',' '};

            Console.WriteLine("Вводите слова, завершая каждое нажатием Enter");
            Console.WriteLine("Для выхода введите EXIT");

            //Ввод данных
            for (; ; )
            {
                word = Console.ReadLine();
                word = word.Trim(spacesToTrim);

                if (word == "EXIT")
                    {

                        Console.WriteLine("Считывание завершено");
                        break;
                    }

                if (CheckName(word))
                {
                    wordsList.Add(word);
                }

                else 
                
                {
                    Console.WriteLine("Проверьте корректность введенного слова"); 
                }
            }

            //Проверка если слова не введены
            if (wordsList.Count == 0) 
            {
                Console.WriteLine("Слова не введены. Выход.");
                
            }

            string[] wordsArray = wordsList.Select(i => i.ToString()).ToArray();

            //Поиск длины самого большого слова
            for (int i = 0; i < wordsArray.Length; i++)    
            {
                if (wordsArray[i].Length > wordWithMaxLength.Length) 
                {
                    wordWithMaxLength = wordsArray[i];
                    MaxLength = wordWithMaxLength.Length;
                }   
            }

            //Проверка на наличие слов с одинаковой длиной с самым большим словом и их вывод

            for (int i = 0; i < wordsArray.Length; i++) 
            {
                if (MaxLength == wordsArray[i].Length) 
                {
                    Console.Write("Самое длинное слово: "+"'"+wordsArray[i].ToUpper());
                    Console.WriteLine("' " + "(" + wordsArray[i].Length + ").");
                }
            
            }
   
        }
    }
}
