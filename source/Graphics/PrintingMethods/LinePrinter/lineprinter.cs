
using GameLibrary.Graphics.Display;

namespace GameLibrary.Graphics {

// prints flagged lines whole
// no analysis. black and white
class LinePrinter : Printer {

    // print frame to console
    public override void updateFrame(Screen screen) {
        for(int i = 0; i < screen.FrameBuffer.flaggedRows.Count; i++) {
            int currentLine = screen.FrameBuffer.flaggedRows[i];
            string printLine = new string(screen.FrameBuffer.state[currentLine]);
            // print with default colors
            Terminal.PrintString(printLine, screen.Position_x, screen.Position_y + currentLine);
        }
        screen.FrameBuffer.flaggedRows.Clear();
    }
}
}