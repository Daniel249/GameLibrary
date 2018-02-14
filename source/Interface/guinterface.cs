using System.Collections.Generic;
using GameLibrary.Interface.Elements;
namespace GameLibrary.Interface {
// contains ui elements and organizes their printing 
//
// info to the user is displayed through GUInterfaces
// potential for start and pause menu
// both are either instances or inherit from GUInterface
// 
class GUInterface {
    // reference to UI Elements
    List<IElement> elements;

    // lopp through elements and render
    public void render() {

    }

    // constructor
    public GUInterface() {
        elements = new List<IElement>();
    } 
}
}