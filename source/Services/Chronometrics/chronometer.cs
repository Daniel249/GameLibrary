

namespace GameLibrary.Services.Chronometrics {
// attackSpeed mechanic
public class Chronometer {
    // number of cycles to reset to 0
    readonly int intervalDelay;
    // present number of cycles
    int timeUnit;
    // if false, tick returns false
    bool isTicking;
    
    // set isTicking
    public void toggle(bool isTick) {
        timeUnit = intervalDelay - 1;
        isTicking = isTick;
    }
    public bool toggle() {
        timeUnit = intervalDelay - 1;
        isTicking = !isTicking;
        return isTicking;
    }
    
    // return true when timeUnit reaches intervalDelay
    public bool tick() {
        if(!isTicking) {
            return false;
        }
        // tick and check
        timeUnit++;
        if(timeUnit == intervalDelay) {
            timeUnit = 0;
            return true;
        } else {
            return false;
        }
    }


    // contructor
    public Chronometer(int delay, bool isActive) {
        intervalDelay = delay;
        timeUnit = 0;
        isTicking = isActive;
    }
}
}