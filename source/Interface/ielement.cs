
using GameLibrary.Graphics;

namespace GameLibrary.Interface {
// inherits from IPrintable
//
// inherited by interface elements
//
// updated through events
interface IElement : IPrintable {

    GUInterface GUInterface { get; }

}
}