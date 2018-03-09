using System;

using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

// static InterfaceElement
class Label : InterfaceElement {

    // constructor

    public Label(String rawTexture, IUpdateable parent, int pos_x, int pos_y) 
    : base(rawTexture, parent, pos_x, pos_y) {

    }
    public Label(Texture texture, IUpdateable parent, int pos_x, int pos_y) 
    : base(texture, parent, pos_x, pos_y) {

    }
}
}