using System;

using GameLibrary.Graphics;
namespace GameLibrary.Interface.Elements {
// GUI elements
// inherits from IElements
// placed in a GUI with a location and can subscribe to events to update their state
class InterfaceElement : IElement{
    // IPrintable implementation
    // reference to screen
    public GUInterface GUInterface { get; private set; }
    // Texture
    public Texture Texture { get; private set; }
    // position in screen
    public int Position_x { get; set; }
    public int Position_y { get; set; }


    // constructor 
    public InterfaceElement(int pos_x, int pos_y) {

    }
}
}