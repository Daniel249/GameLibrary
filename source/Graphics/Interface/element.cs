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
    protected void buildInterface(Texture texture, IUpdateable parent, int pos_x, int pos_y) {
        Texture = texture;
        Parent = parent;
        Position_x = pos_x;
        Position_y = pos_y;
    }

    // overloads
    public InterfaceElement(Texture texture, IUpdateable parent, int pos_x, int pos_y) {
        buildInterface(texture, parent, pos_x, pos_y);
    }
    public InterfaceElement(String rawTexture, IUpdateable parent, int pos_x, int pos_y) {
        // build Texture and pass it to factory
        char[][] code = new char[][] {
            rawTexture.ToCharArray()
        };
        Texture texture = new Texture(code, Terminal.DefaultBackColor, Terminal.DefaultForeColor);
        
        buildInterface(texture, parent, pos_x, pos_y);
    }
}
}