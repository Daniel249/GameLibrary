using System;
using System.Diagnostics;
using System.Threading;

using SB.Assets;
using GameLibrary.Services.Chronometrics;
// print to console on tick
// access player health to print
using GameLibrary.Platform;
using SB;

namespace GameLibrary.Interface {
class Watch : IChronometric{
    int queueCounter;
    Stopwatch stopwatch;
    Stopwatch timer;

    // main method
    public string getTime() {
        queueCounter++;
        string str = queueCounter + "    " + stopwatch.Elapsed.ToString() + "      " 
            + (1000 / timer.Elapsed.TotalMilliseconds).ToString();

        timer.Restart();
        return str;
    }


    // ichronometrici implementation
    Chronometer cronometro;
    public bool tick() {
        if(cronometro.tick()) {
            UserInterface.FPSLabel.Edit(getTime());

            string str = "health: " + SBGame.getPlayer().getHealth() + "  ";
            UserInterface.HealthLabel.Edit(str);
            return true;
        } else {
            return false;
        }
    }

    // toggle chronometer
    public void toggle(bool on_off) {
        cronometro.toggle(on_off);
    }
    public bool toggle() {
        return cronometro.toggle();
    }

    // constructor
    public Watch(int cyclesToTick) {
        cronometro = new Chronometer(cyclesToTick, true);
        stopwatch = new Stopwatch();
        stopwatch.Start();
        timer = new Stopwatch();
        timer.Start();
    }
}

}