
namespace GameLibrary.Graphics {

// Screen and IForm inherit. 
// creates a tree with each node having a reference to its parent
// Screen as root
interface IUpdateable {

    // update lower node passed as parameter
    void updateprint(IPrintable child, int relative_x, int relative_y);
    void updatedelete(IPrintable child, int relative_x, int relative_y);
}
}