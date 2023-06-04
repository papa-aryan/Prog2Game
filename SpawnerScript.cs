using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject coinObject; // lägger in coinprefaben
    public GameObject mobObject; // där man lägger in mob prefaben

    // för att spawna objecten
    public void spawnCoin(int x1, int x2, int y) 
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y); // skapa position för spawn inom ett givet random x värde
        Instantiate(coinObject, randomSpawnPosition, Quaternion.identity); // spawn obekteet, sista är för den ska ha fast Z värde
    }
    public void spawnMob(int x1, int x2, int y)
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y);
        Instantiate(mobObject, randomSpawnPosition, Quaternion.identity); 
    }
 
}
