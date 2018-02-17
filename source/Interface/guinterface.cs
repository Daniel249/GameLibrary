using System;
using System.Collections.Generic;

using GameLibrary.Graphics;
using GameLibrary.Interface.Elements;

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
    Screen Screen;
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
    public virtual void updateFrame() {
        for(int y = 0; y < Frame.Size_y; y++) {
            Array.Copy (
                Frame.state[y], 0, Screen.FrameBuffer.state[Position_y + y],
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