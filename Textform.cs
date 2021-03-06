﻿using System;
using System.Threading;

namespace TextVenture
{
    abstract class Textform
    {
        public int _delay = 100; //this is in milliseconds
    }
    class NormalText : Textform
    {
        public NormalText(int _delay = 100)
        {
            this._delay = _delay;
        }
        public void Text(string _input, ConsoleColor _color = ConsoleColor.White)
        {
            int tempspeed = 0;
            tempspeed += _delay;
            ConsoleColor originalcolor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            char[] charArr = _input.ToCharArray();
            ConsoleKeyInfo _key;
            foreach (Char cher in charArr)
            {
                Console.Write(cher);
                if (Console.KeyAvailable)
                {
                    int origX = Console.CursorLeft, origY = Console.CursorTop;
                    _key = Console.ReadKey();
                    switch (_key.Key)
                    {
                        case (ConsoleKey.Enter):
                            tempspeed = tempspeed / 10;
                            break;
                        default:
                            break;
                    }
                    Console.SetCursorPosition(origX,origY);

                }
                Thread.Sleep(tempspeed);
            }



            Console.ForegroundColor = originalcolor;
            Console.WriteLine();
        }
    }
}
