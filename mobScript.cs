using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mobScript : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed;
    private int lockpos = 0;

    //  int importYPos;

    private void Awake()
    {
        Destroy(gameObject, 5); 
    }
    void Start()
    {
        speed = Random.Range(-6, -2);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // denna i update ist för start så den inte ska flyga åt andra hållet när gubben collidas
        rb.velocity = new Vector2(speed, rb.velocity.y); //Random.Range(-10, -18)
        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos); // så den inte har någon rotation (2d spel)

    }

}
