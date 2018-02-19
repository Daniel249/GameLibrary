using System;

using SB.Objects;
using GameLibrary.Platform;
using GameLibrary.Graphics.Display;
using SB;

namespace GameLibrary.Graphics {
// old printing algorithm. there is no frame as buffer
// takes printable and screen and prints it directly
class LegacyPrinter : Printer {
    // Printer implementation
    // already print in legacyinterface
    public void updateFrame(Screen screen) {

    }

    // main print method
    public static void printdelete(IPrintable entity, Screen screen, bool print) {
        // defines reference and colors to print
        // color and reference
        IPrintable reference;
        ConsoleColor bcolor;
        ConsoleColor fcolor;

        // print defines action to either print or delete on console and reference map
        if(print) {
            reference = entity;
            bcolor = entity.Texture.BackgroundColor;
            fcolor = entity.Texture.ForegroundColor;
        } else {
            reference = null;
            bcolor = Terminal.DefaultBackColor;
            fcolor = Terminal.DefaultForeColor;
        }

        // other values and references
        int pos_x = entity.Position_x;
        int pos_y = entity.Position_y;
        int map_x = SBGame.getMap().Size_x;
        int map_y = SBGame.getMap().Size_y;

        // loop and limit start as values for a normal for-loop,
        // equal to 0 and max value respectively.
        // they change based on offset to only print code inside map
        int loop_x = 0;
        int loop_y = 0;
        int limit_x = entity.Texture.GetLength(true);
        int limit_y = entity.Texture.GetLength(false);

        // calc offset
        // limit and loop both as input and outputs
        Render.calcOffset(map_x, pos_x, ref limit_x, out loop_x);
        Render.calcOffset(map_y, pos_y, ref limit_y, out loop_y);

        
        // loop from loop_x to limit. changes based on offset 
        for(int y = loop_y; y < limit_y; y++) {
        // print each line to console on outter loop
            // both x and y locations are based off of current loop_x/y. but loop_x stays 0
            int printPosition_x = pos_x + screen.Position_x + loop_x;
            int printPosition_y = pos_y + screen.Position_y + y /* current loop_y */;

            string printLine;
            if(print) {
                printLine = Render.getPrintable(entity.Texture.getCode(y), loop_x, limit_x);
            } else {
                printLine = new string(new char[limit_x - loop_x]);
            }

            Terminal.PrintString(printLine, printPosition_x, printPosition_y, bcolor, fcolor);

            if(entity is Unit) {
                // checks until custom length, because of shorter arrays
                for(int x = loop_x; x < entity.Texture.getCode(y).Length; x++) {
                    char code = entity.Texture.getCode(y,x);
                    if(code != '\0' && code != ' ') {
                        SBGame.getMap().setMap((Entity)reference, pos_x + x, pos_y + y);
                    }
                }
            }
        }

    }




    // not in use
    
    // print and erase
    public static void PrintText(string msg, int pos_x, int pos_y, ConsoleColor bcolor) {

    }
    public static void printTo(int pos_x, int pos_y, string code, ConsoleColor fcolor, ConsoleColor bcolor) {
        PrintText(code, pos_x, pos_y, bcolor);
    }
    public static void eraseFrom(int pos_x, int pos_y, ConsoleColor bcolor) {
        PrintText(" ", pos_x, pos_y, bcolor);
    }
}
}
