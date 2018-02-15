using GameLibrary.Services;

namespace GameLibrary.Graphics {
// each of the frames that get printed to the command prompt
// gets passed to be printed

// frame building logic either here or in a frame builder
public class Frame {

    public readonly char[][] Snapshot;

    public Frame(int size_x, int size_y) {
        Snapshot = MapInitializer.CreateArray<char>(size_x, size_y);
    }
}
}