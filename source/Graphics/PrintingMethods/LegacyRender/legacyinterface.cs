using GameLibrary.Interface;
using SB.Objects;
using SB;

namespace GameLibrary.Graphics {
class LegacyInterface : GUInterface {
    public Map map { get; private set; }

    public override void print(IPrintable printable) {
        LegacyPrinter.printdelete(printable, Screen, true);
        // Unit u = printable as Unit;
        // if(u != null && u.hitbox != null) {
        //     Render.print(u.hitbox, printable.Position_x, printable.Position_y, map);
        //     map.flaggedRows.Clear();
        // }
        
    }
    public override void delete(IPrintable printable) {
        LegacyPrinter.printdelete(printable, Screen, false);

        // Unit u = printable as Unit;
        // if(u != null && u.hitbox != null) {
        //     Render.delete(u.hitbox, printable.Position_x, printable.Position_y, map);
        // }
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