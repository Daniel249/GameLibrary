
namespace GameLibrary.Services {
// initializes a rectangular jagged array
// takes type and 2 dimensions
static class TextureInitializer {
    public static T[][] CreateArray<T>(int cols, int rows) {
        T[][] rectArray = new T[rows][];

        for(int i = 0; i < rectArray.GetLength(0); i++) {
            rectArray[i] = new T[cols];
        }
        return rectArray;
    }

    public static void Fill<T>(this T[] originalArray, T with) {
        for(int i = 0; i < originalArray.Length; i++){
            originalArray[i] = with;
        }
    }

    // make char[][] out of string[]
    public static char[][] Pixelate(this string[] original) {
        // build Texture and pass it to factory
        char[][] code = new char[original.Length][];
        for(int i = 0; i < original.Length; i++) {
            code[i] = original[i].ToCharArray();
        }
        return code;
    }
}
}