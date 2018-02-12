using System;

namespace GameLibrary.Interface.Elements {
// GUI elements
// inherits from IElements
// placed in a GUI with a location and can subscribe to events to update their state
class InterfaceElement : IElement {
    char[][] texture;
    public char[][] getTexture() {
        return texture;
    }
}
}