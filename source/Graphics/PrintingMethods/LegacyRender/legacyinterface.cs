using GameLibrary.Interface;
using SB;

namespace GameLibrary.Graphics {
class LegacyInterface : GUInterface {
    public Map map { get; private set; }

    public override void print(IPrintable printable) {
        LegacyPrinter.printdelete(printable, Screen, true);
    }
    public override void delete(IPrintable printable) {
        LegacyPrinter.printdelete(printable, Screen, false);
    }
    public override void updateFrame() {

    }


    // constructor
    public LegacyInterface(Map mapp, Screen screen, int pos_x, int pos_y,int  size_x, int size_y) 
        : base(screen, pos_x, pos_y, size_x, size_y) {
        map = mapp;
    }

}
}