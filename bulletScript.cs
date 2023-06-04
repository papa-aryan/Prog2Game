using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    private float bulletDirection;

    // efter 3 sekunder den försvinner själv så de inte ska bli 1000 bullet objects
    private void Awake()
    {
        Destroy(gameObject, 3); //  delete objektet efter 3 sekunder
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // rb.AddForce(transform.forward * bulletSpeed * bulletDirection);
        rb.velocity = new Vector2 (bulletSpeed * bulletDirection , 0);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "mob1")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerMovement>().addCoin();
            FindObjectOfType<textScripts>().addToCoinCounter();
        }
    }

    public void getBoolInput(bool facingRight)
    {
        if (facingRight == true)
        {
            bulletDirection = 1;
        }
        if (facingRight == false)
        {
            bulletDirection = -1;
        }
    }
}
