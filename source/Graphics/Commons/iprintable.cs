using System;

namespace GameLibrary.Graphics {
// can give information to be printed
// inherted by GUI elements and Visible objects
interface IPrintable : IForm {
    // texture
    Texture Texture { get; }

}
}