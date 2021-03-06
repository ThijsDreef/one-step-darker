﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance { get; private set; }

    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private TextAsset[] levelFile;
    [SerializeField]
    private int currentLevel = 0;

    private bool transitionLevel = false;

    [SerializeField]
    private PlayerBehaviour player;

    private GameGrid grid;
    private Steps steps;

    private bool GamePaused = false;

    IEnumerator nextLevelStart() {
        steps.setZero();

        yield return new WaitForSeconds(1.7f);
        currentLevel++;
        Debug.Log(currentLevel >= levelFile.Length);
        if (currentLevel >= levelFile.Length) {
            uIManager.titleScreen();  
        } else setLevel(levelFile[currentLevel]);
    }

    public void nextLevel() {
        if (transitionLevel) return;
        transitionLevel = true;
        StartCoroutine(nextLevelStart());
    }
    private void setLevel(TextAsset asset) {
        Level level = LevelGrid.generateLevel(asset);
        grid.spawnLevel(level.blocks);
        player.transform.position = grid.convertGridPosToWorld(level.playerPosition);
        player.SetTarget(player.transform.position);
        steps.setSteps(level.steps);
        transitionLevel = false;
        SFX.Instance.playSound(SoundType.RESPAWN);
    }

    public void setLevel(int level) {
        setLevel(levelFile[level]);
        currentLevel = level;
    }

    public void PauseGame(bool value) {
        GamePaused = value;
    }

    // Start is called before the first frame update
    void Start() {
        if (!Instance) Instance = this;
        else {
            Destroy(this);
            return;
        }
        grid = GetComponent<GameGrid>();
        steps = GetComponent<Steps>();
        setLevel(levelFile[currentLevel]);
    }


    // Update is called once per frame
    void Update() {
        if (!player.isReadyForNextCommand || GamePaused) return;
        if (!steps.canTakeStep() && !transitionLevel) {
            setLevel(levelFile[currentLevel]);
            return;
        }

        if (Input.GetKeyUp(KeyCode.R) && !transitionLevel) {
            setLevel(levelFile[currentLevel]);
            return;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(1, 0), player.gameObject)) {
                steps.stepDown();
                player.SetTarget(grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(1, 0)));
                player.moveTo();
            } else {
                SFX.Instance.playSound(SoundType.INCORRECT_MOVE);
            }
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(-1, 0), player.gameObject)) {
                steps.stepDown();
                player.SetTarget(grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(-1, 0)));
                player.moveTo();
            } else {
                SFX.Instance.playSound(SoundType.INCORRECT_MOVE);
            }
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, 1), player.gameObject)) {
                steps.stepDown();
                player.SetTarget(grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, 1)));
                player.moveTo();
            }
            else {
                SFX.Instance.playSound(SoundType.INCORRECT_MOVE);
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (grid.checkMove(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, -1), player.gameObject)) {
                steps.stepDown();
                player.SetTarget(grid.convertGridPosToWorld(grid.convertPosToGrid(player.transform.position) + new Vector2Int(0, -1)));
                player.moveTo();
            } else {
                SFX.Instance.playSound(SoundType.INCORRECT_MOVE);
            }
        }
    }
}
