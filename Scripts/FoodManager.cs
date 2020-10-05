using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int SpawnCount = 100;
    public List<GameObject> SpawnLocations;
    public GameObject Food;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFood(SpawnCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void SpawnFood(int Count)
    {
        int CountLeft = Count;


        while (CountLeft > 0)
        {
            GameObject TempSpawnLocation = SpawnLocations[Random.Range(0, SpawnLocations.Count - 1)];
            if (TempSpawnLocation.transform.childCount == 0)
            {
                GameObject TempObj = Instantiate(Food);
                TempObj.transform.parent = TempSpawnLocation.transform;
                TempObj.transform.position = TempSpawnLocation.transform.position;
                CountLeft--;
            }
        }
    }
}
