using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPMAZEGEN : MonoBehaviour
{
    public GameObject Wall;
    public float WallLength = 5.0f;
    public int xSize=5;
    public int ySize=5;
    private Vector3 InitPos;

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateWalls()
    {
        InitPos = new Vector3((-xSize / 2) + WallLength / 2, 0.0f, (-ySize / 2) + WallLength / 2);
        Vector3 myPos = InitPos;
        GameObject tempWall;


        //for X Axis
        for (int i = 0; i < ySize; i++)
        {
            for(int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(InitPos.x + (j * WallLength) - WallLength / 2, 0.0f, InitPos.z + (i * WallLength) - WallLength/2);
                tempWall = Instantiate(Wall, myPos, Quaternion.identity) as GameObject;
                tempWall.transform.parent = gameObject.transform;
            }
        }
        //for Y Axis
        for (int i = 0; i <= ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                myPos = new Vector3(InitPos.x + (j * WallLength), 0.0f, InitPos.z + (i * WallLength) - WallLength);
                tempWall = Instantiate(Wall, myPos, Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;
                tempWall.transform.parent = gameObject.transform;

            }
        }
    }
}
