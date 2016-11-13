using UnityEngine;
using System.Collections;

public class GridLogic : MonoBehaviour {

    public Transform CellPrefab;
    public Vector2 GridSize;
    public Transform[,] Grid;
	// Use this for initialization
	void Start () {
        CreateGrid();
        SetRandomTerrain();
        SetNeighbors();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CreateGrid() {
        Grid = new Transform[(int)GridSize.x, (int)GridSize.y];
        for (int i = 0; i < GridSize.x; i++)
        {
            for (int j = 0; j < GridSize.y; j++)
            {
                Transform newCell;
                newCell= (Transform) Instantiate(CellPrefab, new Vector2(transform.position.x + i*2.56f, transform.position.y - j*2.56f), Quaternion.identity);
                newCell.name = string.Format("{0},{1}", i,j);
                newCell.GetComponent<CellLogic>().GridPos = new Vector2(i,j);
                newCell.parent = transform;
                Grid[i, j] = newCell;
            }
        }
    }
    void SetRandomTerrain() {
        foreach (Transform child in transform) {
            int tempTerrain = Random.Range(0, 2);
            child.GetComponent<CellLogic>().TerrainType = tempTerrain;
        }
    }
    void SetNeighbors() {
        for (int i = 0; i < GridSize.x; i++)
        {
            for (int j = 0; j < GridSize.y; j++)
            {
                Transform tempCell = Grid[i, j];
                CellLogic tempScript = tempCell.GetComponent<CellLogic>();
                if (i != 0) {
                    tempScript.Neighbors.Add(Grid[i - 1, j]);
                }
                if (j != 0)
                {
                    tempScript.Neighbors.Add(Grid[i, j - 1]);
                }
                if (i != GridSize.x - 1)
                {
                    tempScript.Neighbors.Add(Grid[i + 1, j]);
                }
                if (j != GridSize.y - 1)
                {
                    tempScript.Neighbors.Add(Grid[i, j + 1]);
                }
            }
        }

    }
}
