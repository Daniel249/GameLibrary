using System;

using GameLibrary.Services;
using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

// static InterfaceElement
class Label : InterfaceElement {
    
    // NOTE: editing the code does not recalc Texture.rank_x
    // which caps the max length to be printed

    public void Edit(Texture texture) {
        Texture = texture;
        Print();
    }
    public void Edit(params string[] args) {
        Texture.setCode(args.Pixelate());
        Print();
    }
    public void Edit(int rowNum, string row) {
        Print();
        //Textire
    }


    // constructor

    public Label(IUpdateable parent, int pos_x, int pos_y, params String[] args) 
    : base(parent, pos_x, pos_y, args) {

    }
    public Label(IUpdateable parent, int pos_x, int pos_y, Texture texture) 
    : base(parent, pos_x, pos_y, texture) {

    }
}
}