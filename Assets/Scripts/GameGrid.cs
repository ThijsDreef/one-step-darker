using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour {
    public Interactable[][] grid;

    [SerializeField]
    private float scale;

    [SerializeField]
    private GameObject[] levelObjects = new GameObject[(int)LevelTypes.NR];

    private bool checkBounds(Vector2Int coord) {
        if (coord.x < 0 || coord.y < 0) return false;
        if (coord.x >= grid.Length || coord.y >= grid[coord.x].Length) return false;
        return true;
    }

    public void spawnLevel(LevelTypes[][] level) {
        foreach(Transform t in transform) {
            Destroy(t.gameObject);
        }


        grid = new Interactable[level.Length][];
        for (int x = 0; x < level.Length; x++) {
            grid[x] = new Interactable[level[x].Length];
            for (int y = 0; y < level[x].Length; y++) {
                GameObject t = Instantiate(levelObjects[(int)level[x][y]], new Vector3(scale * (x), 0, scale * (y)), Quaternion.identity);
                grid[x][y] = t.GetComponent<Interactable>();
                grid[x][y]?.setGrid(this);

                t.transform.parent = this.transform;
                t.transform.localScale *= scale;
            }
        }
    }

    public Vector2Int convertPosToGrid(Vector3 pos) {
        return new Vector2Int(Mathf.RoundToInt(pos.x / scale), Mathf.RoundToInt(pos.z / scale));
    }

    public Vector3 convertGridPosToWorld(Vector2Int to) {
        return new Vector3(to.x * scale, 1, to.y * scale);
    }

    public bool checkMove(Vector2Int to, GameObject o) {
        if (!checkBounds(to)) return false;
        Interactable t = grid[to.x][to.y];
        if (!t) return true;
        t.interact(o);
        return t.isFree();
    }
}
