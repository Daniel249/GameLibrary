using System;
using GameLibrary.Graphics;
namespace GameLibrary.Graphics.Display {
static class Terminal {
    // numbers based on testing
    // not in use
    public static int Size_x { get; private set; } //= 240;
    public static int Size_y { get; private set; } //= 72;

    // methods
    // set console size
    public static void setSize() {
        // get size dinamically
        Size_x = Console.LargestWindowWidth;
        Size_y = Console.LargestWindowHeight;
        // set buffer automatically
        Console.SetWindowSize(Size_x, Size_y);
        Console.SetBufferSize(Size_x, Size_y);

        Console.Clear();
        Console.CursorVisible = false;
        //Console.SetWindowPosition(0, 0);
    }


    // main print to console method. print strings
    public static void PrintString(string str, int pos_x, int pos_y, ConsoleColor bcolor, ConsoleColor fcolor) {
        Console.SetCursorPosition(pos_x, pos_y);
        Console.ForegroundColor = fcolor;
        Console.BackgroundColor = bcolor;
        Console.Write(str);
        Console.ResetColor();
    }
    // print with defult colors
    public static void PrintString(string str, int pos_x, int pos_y) {
        PrintString(str, pos_x, pos_y, DefaultBackColor, DefaultForeColor);
    }


    public static void PrintChar(char cha, int pos_x, int pos_y, ConsoleColor bcolor, ConsoleColor fcolor) {
        Console.SetCursorPosition(pos_x, pos_y);
        Console.ForegroundColor = fcolor;
        Console.BackgroundColor = bcolor;
        Console.Write(cha);
        Console.ResetColor();
    }


    // default console colors
    public const ConsoleColor DefaultBackColor = ConsoleColor.Black;
    public const ConsoleColor DefaultForeColor = ConsoleColor.White;
}
}