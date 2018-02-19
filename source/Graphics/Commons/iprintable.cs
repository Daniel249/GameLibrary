using System;

namespace GameLibrary.Graphics {
// can give information to be printed
// inherted by GUI elements and Visible objects
public interface IPrintable {
    // texture
    Texture Texture { get; }

    // position
    int Position_x { get; }
    int Position_y { get; }

}
}