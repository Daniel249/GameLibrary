

namespace GameLibrary.Graphics {


interface IForm {
    // parent node reference
    IUpdateable Parent { get; }
    // position to pass to parent.update
    int Position_x { get; }
    int Position_y { get; }
}
}