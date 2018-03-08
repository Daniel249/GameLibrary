

namespace GameLibrary.Graphics {
class Screen : IUpdateable {

    // printer and frame references
    private Printer Printer { get; set; }
    public Frame FrameBuffer { get; private set; }

    // screen size. matches frame 
    public int Size_x { get; private set; }
    public int Size_y { get; private set; }

    // IForm implementation
    // position in console
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }
    public void updateprint(IPrintable child, int relative_x, int relative_y) {
        Printer.print(child, relative_x, relative_y, this);
    }
    public void updatedelete(IPrintable child, int relative_x, int relative_y) {
        Printer.delete(child, relative_x, relative_y, this);
    }

    // methods
    // print frame
    public void updateFrame() {
        Printer.updateFrame(this);
        FrameBuffer.flaggedRows.Clear();
    }


    // constructor 
    public Screen(int size_x, int size_y, Printer assignedPrinter) {
        Position_x = 5;
        Position_y = 5;
        Size_x = size_x;
        Size_y = size_y;
        FrameBuffer = new Frame(size_x, size_y);
        Printer = assignedPrinter;
    }


    // not in use

    // render printable in frame
    // public void delete(IPrintable printable) {
    //     Printer.delete(printable, this);
    // }
    // public void print(IPrintable printable) {
    //     Printer.print(printable, this);
    // }


}

}