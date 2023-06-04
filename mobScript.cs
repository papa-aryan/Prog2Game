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
        // denna i update ist f�r start s� den inte ska flyga �t andra h�llet n�r gubben collidas
        rb.velocity = new Vector2(speed, rb.velocity.y); //Random.Range(-10, -18)
        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos); // s� den inte har n�gon rotation (2d spel)

    }

}
