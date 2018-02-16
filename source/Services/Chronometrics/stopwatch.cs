using System;
using System.Diagnostics;
using System.Threading;
using GameLibrary.Services.Chronometrics;
// print to console on tick
using GameLibrary.Graphics.Display;
// access player health to print
using GameLibrary.Platform;

namespace GameLibrary.Interface {
class Watch : IChronometric{
    int queueCounter;
    Stopwatch stopwatch;
    Stopwatch timer;

    // main method
    public string getTime() {
        queueCounter++;
        string str = queueCounter + "    " + stopwatch.Elapsed.ToString() + "      " 
            + timer.Elapsed.TotalMilliseconds.ToString();

        timer.Restart();
        return str;
    }


    // ichronometrici implementation
    Chronometer cronometro;
    public bool tick() {
        if(cronometro.tick()) {
            Terminal.PrintString(getTime(), Terminal.Size_x - 40, 0, Terminal.DefaultBackColor, Terminal.DefaultForeColor);

            Terminal.PrintString("health: " + Game.getPlayer().getHealth() + "  ", Terminal.Size_x - 80, 0, 
                Terminal.DefaultBackColor, Terminal.DefaultForeColor);

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