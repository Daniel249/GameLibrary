using System;

using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

class InterfaceElement : IPrintable {

    // IPrintable implementation
    public virtual Texture Texture { get; private set; }


    // IForm implementations

    public IUpdateable Parent { get; private set; }

    // position
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }


    // constructor 

    // main constructor method
    protected void buildInterface(IUpdateable parent, int pos_x, int pos_y, Texture texture) {
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
        // build Texture and pass it to factory
        char[][] code = new char[args.Length][];
        for(int i = 0; i < args.Length; i++) {
            code[i] = args[i].ToCharArray();
        }
        Texture texture = new Texture(code, Terminal.DefaultBackColor, Terminal.DefaultForeColor);

        buildInterface(parent, pos_x, pos_y, texture);
    }
}
}