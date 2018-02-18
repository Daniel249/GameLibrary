using System;
// using System.Collections.Generic;
namespace GameLibrary.Graphics {

public class ITexture<T> {

    // ascii code
    // non '\0' spaces printed and deleted
    T[][] code;

    // get set
    public void setCode(T[][] newCode) {
        code = newCode;
    }
    public T[][] getCode() {
        // not used
        return code;
    }
    // get at certain coordinates
    public T getCode(int coord_y, int coord_x) {
        return code[coord_y][coord_x];
    }
    public T[] getCode(int coord_y) {
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
    public ITexture(T[][] _code) {
        code = _code;
        calcRank();
    }
}
}