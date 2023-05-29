using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject coinObject;
    public GameObject mobObject;
    // Update is called once per frame
  /*  void Update()
    {
            
    } */
    public void spawnCoin(int x1, int x2, int y)
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y);
        Instantiate(coinObject, randomSpawnPosition, Quaternion.identity); // sista är för den inte ska ha 
    }
    public void spawnMob(int x1, int x2, int y)
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y);
        Instantiate(mobObject, randomSpawnPosition, Quaternion.identity); // sista är för den inte ska ha 
    }
 
}
