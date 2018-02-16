

namespace GameLibrary.Graphics {
public class Screen {
    // position in console
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }

    // printer and frame references
    public Frame FrameBuffer { get; private set; }
    private Printer Printer { get; set; }


    // methods
    // print frame
    public void updateFrame() {
        Printer.updateFrame(this);
    }

    // render printable in frame
    public void delete(IPrintable printable) {
        Printer.delete(printable, this);
    }
    public void print(IPrintable printable) {
        Printer.print(printable, this);
    }


    // constructor 
    public Screen(int size_x, int size_y, Printer assignedPrinter) {
        Position_x = 0;
        Position_y = 0;
        FrameBuffer = new Frame(size_x, size_y);
        Printer = assignedPrinter;
    }
}

}