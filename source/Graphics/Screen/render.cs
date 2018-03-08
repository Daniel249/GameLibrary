using System;

namespace GameLibrary.Graphics {

// render T[][] in snapshot<T>
static class Render {
    
    // public methods
    public static void print<T>(ITexture<T> printable, int pos_x, int pos_y, ISnapshot<T> frame) {
        printdelete(printable, pos_x, pos_y,  frame, true);
    }
    public static void delete<T>(ITexture<T> printable, int pos_x, int pos_y, ISnapshot<T> frame) {
        printdelete(printable, pos_x, pos_y, frame, false);
    }

    // main render method
    static void printdelete<T>(ITexture<T> code, int pos_x, int pos_y, ISnapshot<T> frame, bool print) {
        // set margins to max
        int loop_x = 0;
        int loop_y = 0;
        int limit_x = code.GetLength(true);
        int limit_y = code.GetLength(false);

        // calc margins actual size
        calcOffset(frame.Size_x, pos_x, 
            ref limit_x, out loop_x);
        calcOffset(frame.Size_y, pos_y, 
            ref limit_y, out loop_y);

        // loop through margin values
        for(int y = loop_y; y < limit_y; y++) {
            // x margin 
            int printLength = code.GetLength(y);
            if(limit_x < code.GetLength(y)) {
                printLength = limit_x;
            }
            // char array to print based on print or delete
            T[] toPrint = code.getCode(y);
            if(!print) {
                toPrint = new T[printLength];
            }
            // row to print. based on printable location
            int rowToPrint = pos_y + y;
            // copy texture to frame
            Array.Copy (
                toPrint, loop_x, frame.state[rowToPrint], pos_x, printLength
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