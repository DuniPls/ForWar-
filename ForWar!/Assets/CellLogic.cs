using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellLogic : MonoBehaviour {

    public int TerrainType = -1;
    public Sprite TestSprite;
    public Sprite[] SpriteArray = new Sprite[3];
    public Vector2 GridPos;
    public List<Transform> Neighbors;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(TerrainType!=-1)
            GetComponent<SpriteRenderer>().sprite = SpriteArray[TerrainType];
        else if (TerrainType == -1)
            GetComponent<SpriteRenderer>().sprite = TestSprite;

    }
}
