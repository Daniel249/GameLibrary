using System;

namespace GameLibrary.Graphics {
public abstract class Printer {
    // legacy render inherits printer but it's the exception in the implementation
    // there is no updateFrame
    // instead print and delete affect the console directly

    // render on frame reference in screen
    public abstract void print(IPrintable printable, Screen screen);
    public abstract void delete(IPrintable printable, Screen screen);
    // print frame in screen
    public abstract void updateFrame(Screen screen);

}
}