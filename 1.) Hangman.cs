using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.__Hangman
{
    enum Menu
    {
        PlayGame = 1,
        Exit
    }

    class Program
    {
        static void Main(string[] args)
        {
            MainMenuScreen();   // เข้าไปที่หน้าเมนูหลักของเกม
        }

        static void MainMenuScreen()
        {
            MainMenuHeadLine();    //เฮดไลน์ของเมนู
            MainMenuChoices();
        }

        static void MainMenuHeadLine()
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("-----------------------");
        }

        static void MainMenuChoices()     //ให้ดูว่าตัวเลือกมีอะไรบ้าง
        {
            Console.WriteLine("1. Playgame");
            Console.WriteLine("2. Exit");

            SelectMenu();     
        }

        static void SelectMenu()        // ที่ๆให้เลือกตัวเลือก 1 เพื่อเริ่มเล่นเกม, 2 เพื่อออก 
        {
            Console.Write("Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            if (menu == Menu.PlayGame)      // หากกด 1 ก็เริ่มทำการสุ่มคำ
            {
                RandomWord();
            }
            else if (menu == Menu.Exit)
            {
                return;                // หากกด 2 ก็คือออก
            }
            else
            {
                Console.WriteLine("Please select the available menu. Enter to Continue.");      // หากใส่นอกเหนือจาก 1 กับ 2 ต้องวนไปเลือกใหม่
                Console.ReadLine();
                Console.Clear();

                MainMenuScreen();
            }
        }

        static void RandomWord()       //Method สำหรับ Random คำ 
        {
            int IncorrectScore = 0;     //จำนวนครั้งที่ตอบผิดเริ่มต้นที่ 0

            string [] Word = { "tennis", "football", "badminton" };
            Random random = new Random();                    //  Random ระหว่าง 3 ตัว
            int resultRandom = random.Next(Word.Length);

            string Answer = Word[resultRandom];        // สร้างตัวแปร Answer แทนค่าของคำตอบ
            int NumOfCharacters = Answer.Length;       // สร้างตัวแปร NumOfCharacters แทนจำนวนตัวอักษรของคำตอบ

            string mark = "_ ";
            string[] GuessedWord = new string[NumOfCharacters];      // สร้าง Array ของ string (ที่เป็น string เพราะมีทั้ง _ กับ "") ชื่อ GuessedWord แล้วเติมขิดให้เท่ากับ NumOfCharacters

            Array.Fill(GuessedWord, mark);    // คำสั่งให้เปลี่ยนทุกตัวใน Array GuessedWord เป็น _

            PlayGame(Answer, NumOfCharacters, IncorrectScore, ref GuessedWord);
        }

        static void PlayGame(string Answer, int NumOfCharacters, int IncorrectScore, ref string[] GuessedWord)
        {
            Console.Clear();

            GameHeadLine();  
            Score(ref IncorrectScore);  
            PlayField(Answer, NumOfCharacters, IncorrectScore, ref GuessedWord);
        }
        
        static void GameHeadLine()     // เฮดไลน์ของหน้าเมนูเล่นเกม
        {
            Console.Clear();
            Console.WriteLine("Play Game Hangman");
            Console.WriteLine("-----------------");

        }

        static int Score(ref int IncorrectScore)      // โชว์จำนวนครั้งที่ตอบผิดในปัจจุบัน
        {
            Console.WriteLine("Incorrect Score: " + IncorrectScore);

            return IncorrectScore;
        }

        static void PlayField(string Answer, int NumOfCharacters, int IncorrectScore, ref string[] GuessedWord) 
        {
            for(int i = 0; i < NumOfCharacters; i++)     // ลูปไว้แสดงจำนวนขีดตามตัวอักษรของคำตอบ
            {
                Console.Write(GuessedWord[i]);
            }

            GuessingTheWord(Answer, NumOfCharacters, ref GuessedWord, ref IncorrectScore);
        }

        static void GuessingTheWord(string Answer, int NumOfCharacters, ref string[] GuessedWord, ref int IncorrectScore)
        {
            char [] answer = new char[NumOfCharacters];        // สร้าง Array ที่เป็น char ชื่อ answer มีช่องให้ใส่เท่ากับจำนวนตัวหนังสือของคำตอบ
            answer = Answer.ToCharArray();                 // เปลี่ยน Answer ที่ random มาให้เป็น char Array จับเท่ากับ answer เพื่อเอาไว้ดูว่าตัวอักษรที่เราจะใส่กับคำตอบตรคงกันไหม
            
            Console.WriteLine("");                    // เว้น 2 บรรทัดเพื่อจะได้ไม่ดูติดกันเกินไปใน Output
            Console.WriteLine("");

            Console.Write("Input letter alphabet: ");
            char AnsLetter = char.Parse(Console.ReadLine());             // สร้างตัวแปร AnsLetter แทนตัวอักษรที่ผู้เล่นจะกรอก

            if (answer.Contains(AnsLetter))           // เงื่อนไขหากตัวอักษรที่กรอก (AnsLetter) ตรงกับตัวอักษรใน answer
            {
                for (int i = 0; i < NumOfCharacters; i++)      // ลูปดูว่าไอตัวอักษรที่ตรงมันอยู่ตรงตำแหน่งไหน
                {
                    if (AnsLetter == answer[i])           // หากเจอตัวที่ตรงแล้วหล่ะก็...
                    {
                        GuessedWord[i] = AnsLetter.ToString();    // ให้แทนตัวอักษรนั้นแทนขีดตรงตำแหน่งตัวอักษรที่ตรง (Array GuessedWord คือ Array ที่มีแต่ขีด)
                    }
                    else
                    {
                        continue;         // หากลูปไม่เจอตัวอักษรที่ตรงก็ให้ทำต่อไปจนกว่าจะลูปเสร็จตาม NumOfCharacters
                    }
                }

                if (String.Concat(GuessedWord) == Answer)        // หลังลูปเสร็จหากเอาตัวอักษรใน GuessedWord มารวมกันแล้วมันตรงกับ Answer ก็ถือว่าชนะเกม
                {
                    Console.WriteLine("You Win!!");
                    return;
                }

                PlayGame(Answer, NumOfCharacters, IncorrectScore, ref GuessedWord);       // หากจบทุกอย่างในลูปนี้แล้วก็ให้วนกลับไปทายต่อ
            }
            else         // เงื่อนไขหากตัวอักษรที่กรอก (AnsLetter) ไม่ตรงกับตัวอักษรใน answer
            {
                IncorrectScore++;     //จำนวนครั้งที่ตอบผิด +1
                if (IncorrectScore == 6)   // ครบ 6 ครั้งเมื่อไหร่ก็แพ้เกม
                {
                    Console.WriteLine("Game Over!!");
                    return;
                }
                PlayGame(Answer, NumOfCharacters, IncorrectScore, ref GuessedWord);  // หากตอบผิดแต่ยีงไม่ครบ 6 ครั้งก็ให้วนกลับไปทายต่อ
            }
        }
    }
}
