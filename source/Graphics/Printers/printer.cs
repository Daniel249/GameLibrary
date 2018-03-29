using System;

namespace GameLibrary.Graphics {
abstract class Printer {
    // legacy render inherits printer but it's the exception in the implementation
    // there is no updateFrame
    // instead print and delete affect the console directly


    // print frame in screen
    public virtual void updateFrame(Screen screen) {
        
    }

    // used by most printers
    // prints to frame with relative position in frame
    public virtual void print(IPrintable printable, int relative_x, int relative_y, Screen screen) {
        Render.print(printable.Texture, relative_x, relative_y, screen.FrameBuffer);
    }
    public virtual void delete(IPrintable printable, int relative_x, int relative_y, Screen screen) {
        Render.delete(printable.Texture, relative_x, relative_y, screen.FrameBuffer);
    }
    // not in use
    // render on frame reference in screen

    // void print(IPrintable printable, Screen screen);
    // void delete(IPrintable printable, Screen screen);
}
}