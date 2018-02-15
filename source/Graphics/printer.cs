using System;

namespace GameLibrary.Graphics {
public abstract class Printer {
    
    public abstract void print(IPrintable printable, Screen screen);
    public abstract void delete(IPrintable printable, Screen screen);
    
    public abstract void updateFrame(Screen screen);

}
}