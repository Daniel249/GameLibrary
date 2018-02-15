using System;

namespace GameLibrary.Services {
// initializes a rectangular jagged array
// takes type and 2 dimensions
static class MapInitializer {
    public static T[][] CreateArray<T>(int cols, int rows) {
        T[][] rectArray = new T[rows][];

        for(int i = 0; i < rectArray.GetLength(0); i++) {
            rectArray[i] = new T[cols];
        }
        return rectArray;
    }
}
}