using System;

using GameLibrary.Graphics;
namespace GameLibrary.Interface.Elements {
// GUI elements
// inherits from IElements
// placed in a GUI with a location and can subscribe to events to update their state
class InterfaceElement : IElement {
    Texture texture;
    int pos_x;
    int pos_y;
    public Texture getTexture() {
        return texture;
    }
    public int getPos_y() {
        return pos_y;
    }
    public int getPos_x() {
        return pos_x;
    }
}
}