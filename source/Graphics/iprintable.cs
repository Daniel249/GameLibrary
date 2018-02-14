using System;

namespace GameLibrary.Graphics {
// can give information to be printed
// inherted by GUI elements and Visible objects
interface IPrintable {
    // get type on runtime
    Texture getTexture();
    // de ayer. agrega generics para que las texturas sean char[][] o string.
    // se olverloadea en el metodo que llama al IPrintable
    int Location_x {get; set;}
    int Location_y {get; set;}
}

}