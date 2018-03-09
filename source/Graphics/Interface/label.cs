using System;

using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

// static InterfaceElement
class Label : InterfaceElement {

    // constructor

    public Label(IUpdateable parent, int pos_x, int pos_y, params String[] args) 
    : base(parent, pos_x, pos_y, args) {

    }
    public Label(IUpdateable parent, int pos_x, int pos_y, Texture texture) 
    : base(parent, pos_x, pos_y, texture) {

    }
}
}