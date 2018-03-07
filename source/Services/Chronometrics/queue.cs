using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

using GameLibrary.Interface;
using GameLibrary.Services.Chronometrics;

namespace GameLibrary.Services {
class Queue {
    // list of units, bullets and weapons
    readonly List<IChronometric> chronoQueue;
    // turn length in ms. Process sleeps that ammoung once per run
    const int sleepDuration = 1000;

    public void addToQueue(IChronometric chrono) {
        chronoQueue.Add(chrono);
    }
    public bool removeFromQueue(IChronometric chrono) {
        return chronoQueue.Remove(chrono);
    }

    public void run() {
        for(int i = 0; i < chronoQueue.Count; i++) {
            IChronometric u = chronoQueue[i];
            // check chronometer
            u.tick();               
        }
    }


    // constructor
    public Queue() {
        chronoQueue = new List<IChronometric>();
        chronoQueue.Add(new Watch(50));
    }
}
}