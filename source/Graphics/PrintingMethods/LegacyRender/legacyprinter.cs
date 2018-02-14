using System;
using System.Linq;

using SB.Objects;
using GameLibrary.Platform.Game;
using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {
class LegacyPrinter : Printer{
    // print and delete methods
    // both use printdelete targeted at certain point to print either a char o a space
    public override void delete(IPrintable entity) {
        printdelete(entity, false);
    }
    public override void updateFrame() {
        
    }
    public static void partialDelete(Entity entity, int speed_x, int speed_y) {

    }
    public override void print(IPrintable entity) {
        printdelete(entity, true);
    }

    // main print method
    void printdelete(IPrintable entity, bool print) {
        // defines reference and colors to print
        // color and reference
        IPrintable reference;
        ConsoleColor bcolor;
        ConsoleColor fcolor;

        // print defines action to either print or delete on console and reference map
        if(print) {
            reference = entity;
            bcolor = entity.getTexture().getBackgroundColor();
            fcolor = entity.getTexture().getForegroundColor();
        } else {
            reference = null;
            bcolor = Terminal.getDefaultBack();
            fcolor = Terminal.getDefaultFore();
        }

        // other values and references
        int pos_x = entity.Location_x;
        int pos_y = entity.Location_y;
        int map_x = Game.getMap().getSize_x();
        int map_y = Game.getMap().getSize_y();
        int console_x = pos_x + Game.getMap().getLocation_x();
        int console_y = pos_y + Game.getMap().getLocation_y();
        Texture texture = entity.getTexture();

        // loop and limit start as values for a normal for-loop,
        // equal to 0 and max value respectively.
        // they change based on offset to only print code inside map
        int loop_x = 0;
        int loop_y = 0;
        int limit_x = entity.getTexture().GetLength(true);
        int limit_y = entity.getTexture().GetLength(false);

        // calc offset
        // apply it directly
        calcOffset(map_x, pos_x, ref limit_x, out loop_x);
        calcOffset(map_y, pos_y, ref limit_y, out loop_y);

        
        // loop from loop_x to limit. changes based on offset 
        for(int y = loop_y; y < limit_y; y++) {
        // print each line to console on outter loop
            // both x and y locations are based off of current loop_x/y. but loop_x stays 0
            int printLocation_x = console_x + loop_x;
            int printLocation_y = console_y + y /* current loop_y */;

            string printLine;
            if(print) {
                printLine = getPrintable(entity.getTexture().getCode(y), loop_x, limit_x);
            } else {
                printLine = new string(new char[limit_x - loop_x]);
            }
            Terminal.PrintString(printLine, printLocation_x, printLocation_y, bcolor, fcolor);
            if(entity is Unit) {
                // checks until custom length, because of shorter arrays
                for(int x = loop_x; x < entity.getTexture().getCode(y).Length; x++) {
                    char code = entity.getTexture().getCode(y,x);
                    if(code != '\0' && code != ' ') {
                        Game.getMap().setMap((Entity)reference, pos_x + x, pos_y + y);
                    }
                }
            }
        
        }
    }

    string getPrintable(char[] material, int start, int limit) {
        // if not out of map. return as is
        if(start == 0 && limit >= material.Length) {
            return new string(material);
        }
        // else make array of right size and copy printable range to it
        char[] toPrint = new char[limit - start];
        Array.Copy(material, start, toPrint, 0, limit);
        return new string(toPrint);
    }

    // cut parts of code[,] which are out of map
    // offset<0 => out of map to the left
    void calcOffset(int mapSize, int entityLocation, 
        ref int entitySize, out int loopStart) {
        loopStart = 0;
        
        int offset = 0;
        int outBound = entityLocation + entitySize - mapSize;
        // calc offset
        if(entityLocation < 0){
            offset = entityLocation;
        } else if(outBound > 0) {
            offset = outBound;
        }

        // offset applied to loop and limit
        if(offset < 0) {
            loopStart = (-1)*offset;
        } else if(offset > 0) {
            entitySize -= offset;
        }
    }


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
