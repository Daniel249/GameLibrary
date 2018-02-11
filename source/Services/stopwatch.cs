using System;
using System.Diagnostics;
using System.Threading;
using GameLibrary.Services.Chronometrics;
// print to console on tick
using GameLibrary.Graphics.Printer;
// access player health to print
using GameLibrary.Platform.Game;

namespace GameLibrary.Interface {
class Watch : IChronometric{
    int queueCounter;
    Stopwatch stopwatch;
    Stopwatch timer;
    public string getTime() {
        queueCounter++;
        string str = queueCounter + "    " + stopwatch.Elapsed.ToString() + "      " + timer.Elapsed.TotalMilliseconds.ToString();
        timer.Restart();
        return str;
    }
    // ichronometrici implementation
    Chronometer cronometro;
    public bool tick() {
        Terminal.PrintString(getTime(), Terminal.getSize_x()-40, 0, Terminal.getDefaultBack(), Terminal.getDefaultFore());
        Terminal.PrintString("health: " + Game.getPlayer().getHealth(), Terminal.getSize_x()-80, 0, Terminal.getDefaultBack(), Terminal.getDefaultFore());
        return cronometro.tick();
    }
    public void toggle(bool on_off) {
        cronometro.toggle(on_off);
    }
    public bool toggle() {
        return cronometro.toggle();
    }

    public Watch(int cyclesToTick) {
        cronometro = new Chronometer(cyclesToTick, true);
        stopwatch = new Stopwatch();
        stopwatch.Start();
        timer = new Stopwatch();
        timer.Start();
    }
}

}