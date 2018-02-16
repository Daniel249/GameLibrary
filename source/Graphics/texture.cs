using System;
// using System.Collections.Generic;
namespace GameLibrary.Graphics {
public class Texture {
    // color
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }



    // ascii code
    // non '\0' spaces printed and deleted
    char[][] code;

    // get set
    public void setCode(char[][]newCode) {
        code = newCode;
    }
    public char[][] getCode() {
        // not used
        return code;
    }
    // get at certain coordinates
    public char getCode(int coord_y, int coord_x) {
        return code[coord_y][coord_x];
    }
    public char[] getCode(int coord_y) {
        return code[coord_y];
    }
    // for compatibility with 2d char array times
    // horizontal length of texture
    public int GetLength(int position_y) {
        return code[position_y].Length;
    }
    int rank_x;
    // return max x length or y length
    public int GetLength(bool isRank_x) {
        if(isRank_x) {
            return rank_x;
        } else {
            return code.Length;
        }
    }
    void calcRank() {
        int maxRank = 0;
        for(int y = 0; y < code.Length; y++) {
            if(maxRank < code[y].Length) {
                maxRank = code[y].Length;
            }
        }
        rank_x =  maxRank;
     }


    // constructor
    public Texture(char[][] _code, ConsoleColor bcolor, ConsoleColor fcolor) {
        code = _code;
        calcRank();
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}
}