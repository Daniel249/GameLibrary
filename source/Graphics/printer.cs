using System;

namespace GameLibrary.Graphics {
    abstract class Printer {
        
        public abstract void print(IPrintable printable);
        public abstract void delete(IPrintable printable);
        
        public abstract void updateFrame();
        // public static Prnter ge
    }
}