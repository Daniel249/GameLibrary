using System;

namespace GameLibrary.Graphics {
// can give information to be printed
// inherted by GUI elements and Visible objects
public interface IPrintable {
    // texture
    Texture Texture { get; }

    // reference to Screen
    Screen Screen { get; }

    // positiont
    int Position_x { get; }
    int Position_y { get; }

}
}