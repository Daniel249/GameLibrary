using System;

namespace GameLibrary.Graphics {
public interface Printer {
    // legacy render inherits printer but it's the exception in the implementation
    // there is no updateFrame
    // instead print and delete affect the console directly

    // render on frame reference in screen
    void print(IPrintable printable, Screen screen);
    void delete(IPrintable printable, Screen screen);
    // print frame in screen
    void updateFrame(Screen screen);

}
}