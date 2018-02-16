using System.Collections.Generic;
using GameLibrary.Services;

namespace GameLibrary.Graphics {
// each of the frames that get printed to the command prompt
// gets passed to be printed

// frame building logic either here or in a frame builder
public class Frame {

    public readonly char[][] Snapshot;
    public int GetLength(bool isRank_x) {
        if(isRank_x) {
            return Snapshot[0].Length;
        } else {
            return Snapshot.Length;
        }
    }
    // public void renderInFrame() {
    //     Array.Copy(
    //         source: printable.Texture.getCode(i), index: 0; 
    //     )
    // }
    List<int> flaggedRows;
    public void flagRow(int rowNum) {
        flaggedRows.Add(rowNum);
    }

    public Frame(int size_x, int size_y) {
        Snapshot = MapInitializer.CreateArray<char>(size_x, size_y);
        flaggedRows = new List<int>();
    }
}
}