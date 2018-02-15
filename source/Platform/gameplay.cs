using System;
using System.Collections.Generic;

using GameLibrary.Graphics.Display;
using GameLibrary.Externals.Reader;
using GameLibrary.Graphics;
using GameLibrary.Services;
using SB;

namespace GameLibrary.Platform {
// holds map battle and queue references
// sets up  and ends the game. runs gameplay skripts
class Game {
    public static void setUp() {
        loadGraphics("./textures.txt");
        // print instructions
        Terminal.PrintString(
            "move: up down keys, left key to stop    toggle fire: F    exit: esc", 
            5, 0, ConsoleColor.Black, ConsoleColor.White
        );
    }

    // read textures.txt and process data
    static bool loadGraphics(string address) {
        Filereader filereader = new Filereader(address);
        filereader.processTextures();
        return true;
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

    
    // map battle queue references
    static Battle battle;
    public static Player getPlayer() {
        return battle.GetPlayer();
    }
    public static Battle getBattle() {
        return battle;
    }
    public static void setBattle(Battle bat) {
        battle = bat;
    }
    public static Map getMap() {
        return battle.getMap();
    }
    public static Queue getQueue() {
        return battle.getQueue();
    }

    static List<Screen> screens = new List<Screen>();
    public static Screen getMainScreen() {
        return screens[0];
    }
    public static void setScreen(Screen main) {
        screens.Add(main);
    }

    public static void printScreen(int screenNum) {
        screens[screenNum].Printer.updateFrame();
    }
}
}