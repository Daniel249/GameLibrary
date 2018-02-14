using System;

using GameLibrary.Graphics;
namespace GameLibrary.Interface.Elements {
// GUI elements
// inherits from IElements
// placed in a GUI with a location and can subscribe to events to update their state
class InterfaceElement : IElement {
    public int Position_x {get; set;}
    public int Position_y {get; set;}
    public Texture Texture {get; private set;}

    // constructor 
    public InterfaceElement(int pos_x, int pos_y) {

    }
}
}