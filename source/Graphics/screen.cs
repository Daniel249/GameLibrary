using GameLibrary.Graphics;

namespace GameLibrary.Graphics {
class Screen {
    readonly Printer printer;
    public Printer Printer {
        get { return printer;}
    }

    // constructor 
    public Screen(Printer assignedPrinter) {
        printer = assignedPrinter;
    }
}

}