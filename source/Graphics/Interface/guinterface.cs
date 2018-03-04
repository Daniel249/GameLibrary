using System;
using System.Collections.Generic;

using GameLibrary.Graphics;
using GameLibrary.Interface;

namespace GameLibrary.Interface {
// contains ui elements and organizes their printing 
//
// info to the user is displayed through GUInterfaces
// potential for start and pause menu
// both are either instances or inherit from GUInterface
// 
// has a frame and compares it to last to know what to print to screen frame 
class GUInterface {
    // reference to screen
    protected Screen Screen { get; private set; }
    // its own frame
    Frame Frame;
    // reference to UI Elements
    List<IPrintable> elements;
    // position
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }


    // lopp through elements and render
    public virtual void print(IPrintable printable) {
        Render.print(printable, Frame);
    }
    public virtual void delete(IPrintable printable) {
        Render.delete(printable, Frame);
    }

    // TODO print only flagged and flag on screen
    public virtual void updateFrame() {
        // loop through flagged in gui
        for(int y = 0; y < Frame.flaggedRows.Count; y++) {
            int row = Frame.flaggedRows[y];
            // try add flagged to screen flags
            Screen.FrameBuffer.flagRow(row);
            // copy to screen frame
            Array.Copy (
                Frame.state[row], 0, Screen.FrameBuffer.state[Position_y + row],
                Position_x, Frame.Size_x
            );
        }
    }

    // constructor
    public GUInterface(Screen screen, int pos_x, int pos_y, int size_x, int size_y) {
        Screen = screen;
        Position_x = pos_x;
        Position_y = pos_y;
        Frame = new Frame(size_x, size_y);
        elements = new List<IPrintable>();
    } 
}
}