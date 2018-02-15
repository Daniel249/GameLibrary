using GameLibrary.Graphics;

namespace GameLibrary.Graphics {
public class Screen {
    public readonly Printer Printer;
    public readonly Frame Frame;
    public void updateFrame() {
        Printer.updateFrame(this);
    }


    // constructor 
    public Screen(Printer assignedPrinter) {
        Printer = assignedPrinter;
    }
}

}