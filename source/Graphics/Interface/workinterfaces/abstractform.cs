
namespace GameLibrary.Graphics {

class AbstractForm : IForm, IUpdateable {
    // IForm implementation

    // reference to parent node
    public IUpdateable Parent { get; private set; }
    public int Position_x { get; private set; }
    public int Position_y { get; private set; }

    // pass printable to parent node with updated position
    public virtual void updateprint(IPrintable child, int relative_x, int relative_y) {
        Parent.updateprint(child, Position_x + relative_x, Position_y + relative_y);
    }
    public virtual void updatedelete(IPrintable child, int relative_x, int relative_y) {
        Parent.updatedelete(child, Position_x + relative_x, Position_y + relative_y);
    }

    // constructor
    public AbstractForm(IUpdateable parentNode, int pos_x, int pos_y) {
        Parent = parentNode;
        Position_x = pos_x;
        Position_y = pos_y;
    }
}
}