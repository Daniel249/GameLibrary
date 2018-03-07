using GameLibrary.Platform;

namespace GameLibrary.Services.Chronometrics {


// has a chronometer with a certain interval
// aplicable to Entitys and weapons. all of which are referenced in Queue.List<IChronometric>
interface IChronometric {
    // main method. does something if chronometer returns true
    bool tick();
    
    // toggle with and without parameter
    void toggle(bool on_off);
    bool toggle();

    // List<IChronometric> interaction
    
    // void addToQueue();
    // bool removeFromQueue();
}
}