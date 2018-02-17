using System;
// using System.Collections.Generic;
namespace GameLibrary.Graphics {
public class Texture : ITexture<char> {
    // color
    public ConsoleColor ForegroundColor { get; set; }
    public ConsoleColor BackgroundColor { get; set; }


    // constructor
    public Texture(char[][] _code, ConsoleColor bcolor, ConsoleColor fcolor)
     : base(_code) {
        ForegroundColor = fcolor;
        BackgroundColor = bcolor;
    }
}
}