using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private bool facingRight;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //inputGetAxis horizontal A ger v�rde -1 och D v�rde +1, anv�nds ist f�r if else.
        if (horizontalInput > 0f)
        {
            facingRight = true;
        }
        if (horizontalInput < 0f)
        {
            facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            // add force till objectet h�ra inte i update i bulletScript
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            FindObjectOfType<bulletScript>().getBoolInput(facingRight);

        }
    }
}



/*
  
 //f�r bullet
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float bulletSpeed = 10; 
  
 

 
 */
