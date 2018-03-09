using System;

using GameLibrary.Services;
using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

class InterfaceElement : IPrintable {

    // IPrintable implementation
    public Texture Texture { get; protected set; }


    // IForm implementations

    public IUpdateable Parent { get; private set; }

    // position
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }

    // update
    public void Print() {
        Parent.updateprint(this, Position_x, Position_y);
    }
    public void Delete() {
        Parent.updatedelete(this, Position_x, Position_y);
    }



    // constructor 

    // main constructor method
    void buildInterface(IUpdateable parent, int pos_x, int pos_y, Texture texture) {
        Texture = texture;
        Parent = parent;
        Position_x = pos_x;
        Position_y = pos_y;
    }

    // overloads
    public InterfaceElement(IUpdateable parent, int pos_x, int pos_y, Texture texture) {
        buildInterface(parent, pos_x, pos_y, texture);
    }
    public InterfaceElement(IUpdateable parent, int pos_x, int pos_y, params string[] args) {
        char[][] code = args.Pixelate();
        Texture texture = new Texture(code, Terminal.DefaultBackColor, Terminal.DefaultForeColor);

        buildInterface(parent, pos_x, pos_y, texture);
    }
}
}