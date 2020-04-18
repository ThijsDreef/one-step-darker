﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField]
    private TextAsset levelFile;

    [SerializeField]
    private GameObject player;

    GameGrid grid;


    public void setLevel(TextAsset asset) {
        Level level = LevelGrid.generateLevel(asset);
        grid.spawnLevel(level.blocks);
        player.transform.position = grid.convertGridPosToWorld(level.playerPosition);
    }

    // Start is called before the first frame update
    void Start() {
        grid = GetComponent<GameGrid>();
        setLevel(levelFile);
    }

    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyUp(KeyCode.D)) {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(1, 0))) {
                player.transform.position = grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(1, 0));
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(-1, 0)))
            {
                player.transform.position = grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(-1, 0));
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, 1)))
            {
                player.transform.position = grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, 1));
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, -1)))
            {
                player.transform.position = grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, -1));
            }
        }
    }
}
