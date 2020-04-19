using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelTypes {
    EMPTY,
    LADDER,
    ROCK,
    CRATE,
    NR
}

public struct Level {
    public LevelTypes[][] blocks;
    public Vector2Int playerPosition;
    public int steps;
}

public class LevelGrid {
    public static Level generateLevel(TextAsset asset) {
        String[] sep = {", "};
        string[] tokens = asset.text.Split(sep, StringSplitOptions.None);
        int s = Int32.Parse(tokens[0]);
        int pxPos = Int32.Parse(tokens[1]);
        int pyPos = Int32.Parse(tokens[2]);
        int xLimit = Int32.Parse(tokens[3]);
        int yLimit = Int32.Parse(tokens[4]);
        LevelTypes[][] types = new LevelTypes[xLimit][];
        for (int x = 0; x < xLimit; x++) {
            types[x] = new LevelTypes[yLimit];
            for (int y = 0; y < yLimit; y++) {  
                types[x][y] = (LevelTypes)Int32.Parse(tokens[5 + x * yLimit + y]);
            }
        }

        return new Level {
            blocks = types,
            playerPosition = new Vector2Int(pxPos, pyPos),
            steps = s
        };
    }
}
