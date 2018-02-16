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
            // copy texture to frame
            Array.Copy (
                toPrint, loop_x, frame.Snapshot[y], printable.Position_x, printLength
            );
            // flag row
            frame.flagRow(y);
         
        }
    }

    // helpers 
    
    // cut parts of code[,] which are out of map
    // offset<0 => out of map to the left
    static void calcOffset(int mapSize, int entityPosition, 
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
}
}