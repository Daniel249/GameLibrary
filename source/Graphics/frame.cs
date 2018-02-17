using System;
using System.Collections.Generic;
using GameLibrary.Services;

namespace GameLibrary.Graphics {
// each of the frames that get printed to the command prompt
// gets passed to be printed

// frame building logic either here or in a frame builder
public class Frame : ISnapshot<char> {

    // ISnapshot implementation

    public char[][] state { get; private set; }

    public int Size_x { get; private set; }
    public int Size_y { get; private set; }


    public List<int> flaggedRows { get; private set; }

    // add if not already in list
    public void flagRow(int rowNum) {
        if(!flaggedRows.Contains(rowNum)) {
            flaggedRows.Add(rowNum);
        }
    }

    public Frame(int size_x, int size_y) {
        Size_x = size_x;
        Size_y = size_y;
        state = TextureInitializer.CreateArray<char>(size_x, size_y);
        flaggedRows = new List<int>();
    }
}
}