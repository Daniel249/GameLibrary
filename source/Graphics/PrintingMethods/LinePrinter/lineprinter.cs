
using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

// prints flagged lines whole
// no analysis. black and white
class LinePrinter : Printer {

    // Printer implementation
    
    // add and remove printables from frame
    public void print(IPrintable printable, Screen screen) {
        Render.print(printable, screen.FrameBuffer);
    }
    public void delete(IPrintable printable, Screen screen) {
        Render.delete(printable, screen.FrameBuffer);
    }

    // print frame to console
    public void updateFrame(Screen screen) {
        for(int i = 0; i < screen.FrameBuffer.flaggedRows.Count; i++) {
            string printLine = new string(screen.FrameBuffer.Snapshot[i]);
            // print with default colors
            Terminal.PrintString(printLine, screen.Position_x, screen.Position_y + screen.FrameBuffer.flaggedRows[i]);
        }
        screen.FrameBuffer.flaggedRows.Clear();
    }
    
}
}