
namespace GameLibrary.Graphics {

// printable can be rendered here
interface ISnapshot<T> {
    // size to calculate offset with printable
    int Size_x { get; }
    int Size_y { get; }

    // the array
    T[][] state { get; }

}
}