using System.Collections.Generic;
using System.Threading;
using GameLibrary;
using GameLibrary.Interface;
using GameLibrary.Graphics.Printer;
using GameLibrary.Services.Chronometrics;
using GameLibrary.Platform.Game;

namespace GameLibrary.Services.Chronometrics {
public class Queue {
    // list of units, bullets and weapons
    readonly List<IChronometric> chronoQueue;
    // turn length in ms. Process sleeps that ammoung once per run
    const int sleepDuration = 10;
    // number of cycles to reset to 0
    const int intervalDelay = 30;

    public void addToQueue(IChronometric chrono) {
        chronoQueue.Add(chrono);
    }
    public bool removeFromQueue(IChronometric chrono) {
        return chronoQueue.Remove(chrono);
    }

    public bool run() {
        // turn Length
        // Thread.Sleep(sleepDuration);

        // all bullets move
        for(int i = 0; i < chronoQueue.Count; i++) {
            IChronometric u = chronoQueue[i];
            // check chronometer
            u.tick();               
        }
        return true;
    }

    // constructor
    public Queue() {
        chronoQueue = new List<IChronometric>();
        chronoQueue.Add(new Watch(50));
    }
}
}