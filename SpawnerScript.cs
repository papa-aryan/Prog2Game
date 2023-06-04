using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject coinObject; // l�gger in coinprefaben
    public GameObject mobObject; // d�r man l�gger in mob prefaben

    // f�r att spawna objecten
    public void spawnCoin(int x1, int x2, int y) 
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y); // skapa position f�r spawn inom ett givet random x v�rde
        Instantiate(coinObject, randomSpawnPosition, Quaternion.identity); // spawn obekteet, sista �r f�r den ska ha fast Z v�rde
    }
    public void spawnMob(int x1, int x2, int y)
    {
        Vector2 randomSpawnPosition = new Vector2(Random.Range(x1, x2), y);
        Instantiate(mobObject, randomSpawnPosition, Quaternion.identity); 
    }
 
}
