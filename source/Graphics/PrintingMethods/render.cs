using System;

namespace GameLibrary.Graphics {
static class Render {
    public static void print(IPrintable printable, Frame frame) {
        printdelete(printable, frame, true);
    }
    public static void delete(IPrintable printable, Frame frame) {
        printdelete(printable, frame, false);
    }

    // main render method
    static void printdelete(IPrintable printable, Frame frame, bool print) {
        // set margins to max
        int loop_x = 0;
        int loop_y = 0;
        int limit_x = printable.Texture.GetLength(true);
        int limit_y = printable.Texture.GetLength(false);

        // calc margins actual size
        calcOffset(frame.GetLength(true), printable.Position_x, 
            ref limit_x, out loop_x);
        calcOffset(frame.GetLength(false), printable.Position_y, 
            ref limit_y, out loop_y);

        // loop through margin values
        for(int y = loop_y; y < limit_y; y++) {
            // x margin 
            int printLength = printable.Texture.GetLength(y);
            if(limit_x < printable.Texture.GetLength(y)) {
                printLength = limit_x;
            }
            // char array to print based on print or delete
            char[] toPrint = printable.Texture.getCode(y);
            if(!print) {
                toPrint = new char[printLength];
            }
            // row to print. based on printable location
            int rowToPrint = printable.Position_y + y;
            // copy texture to frame
            Array.Copy (
                toPrint, loop_x, frame.Snapshot[rowToPrint], printable.Position_x, printLength
            );
            // flag row
            frame.flagRow(rowToPrint);
         
        }
    }

    // helpers 

    // cut parts of code[,] which are out of map
    // offset<0 => out of map to the left
    public static void calcOffset(int mapSize, int entityPosition, 
        ref int entitySize, out int loopStart) {
        loopStart = 0;
        
        int offset = 0;
        int outBound = entityPosition + entitySize - mapSize;
        // calc offset
        if(entityPosition < 0){
            offset = entityPosition;
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


    public static string getPrintable(char[] material, int start, int limit) {
        // if not out of map. return as is
        if(start == 0 && limit >= material.Length) {
            return new string(material);
        } else {
            // else make array of right size and copy printable range to it
            char[] toPrint = new char[limit - start];
            Array.Copy(material, start, toPrint, 0, limit - start);
            return new string(toPrint);
        }
    }
}
}