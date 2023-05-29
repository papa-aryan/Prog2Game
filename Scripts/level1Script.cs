using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // mobs?!
        FindObjectOfType<SpawnerScript>().spawnMob(-10,10,-17);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
