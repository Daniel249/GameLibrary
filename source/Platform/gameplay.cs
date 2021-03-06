using System;
using System.Collections.Generic;

using GameLibrary.Graphics;
using SB;

namespace GameLibrary.Platform {
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
class Game {
    public static Game Instance { get; private set; }
    public static void setGame(Game game) {
        Instance = game;
    }
    public virtual void setUp() {

    }


    // if false end game
    static bool continueGame = true;
    public static bool getContinueGame() {
        return continueGame;
    }
    // if escape key is pressed, end game
    public static bool processKey(ConsoleKeyInfo key) {
        if(key.Key == ConsoleKey.Escape) {
            endGame();
        }
        return false;
    }
    // set game to end on next battle cycle
    static void endGame() {
        continueGame = false;
    }

    
    // screen control 
    static List<Screen> screens = new List<Screen>();

    // print certain screen
    public static void printScreen(int num) {
        screens[num].updateFrame();
    }

    // print all screens
    public static void printScreen() {
        for(int i = 0; i <screens.Count; i++) {
            screens[i].updateFrame();
        }
    }

    // get set
    public static Screen getMainScreen() {
        return screens[0];
    }
    public static void setScreen(Screen screen) {
        screens.Add(screen);
    }

}
}