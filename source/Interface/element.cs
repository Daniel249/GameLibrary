using System;

using GameLibrary.Graphics;
namespace GameLibrary.Interface.Elements {
// GUI elements
// inherits from IElements
// placed in a GUI with a location and can subscribe to events to update their state
class InterfaceElement : IElement {
    public int Location_x {get; set;}
    public int Location_y {get; set;}
    Texture texture;
    public Texture getTexture() {
        return texture;
    }

    // constructor 
    public InterfaceElement(int pos_x, int pos_y) {

    }
}
}