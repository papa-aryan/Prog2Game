using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //apply forces to the rigid body in order for the player to move
    // vrf nt bara ändra dens x värde?
    
    public healthBar healthBar;
    public textScripts textScripts;
    [SerializeField] private float playerSpeed; //SF så dene accessible från unity
    private Rigidbody2D body;
    private float scaleDownSize = 0.6f; //varför måste float ha f efter?
    private Animator animator;
    private bool grounded;
    private bool insideShop = false;
    private float lockPos = 0;
    private float Stamina = 0;
    private bool ifSprinting = false;
    private int coins = 0;
    private float tid;
    private float maxHealth = 100;
    private float currentHealth;
    // private void Awake()
    // {
    //     body = GetComponent<Rigidbody2D>();
    // }

    void Start()
    { 
        body = GetComponent<Rigidbody2D>(); // checkar om det finns en component "Rigidbody2D", sen store den i body variabeln. "used to get references"
        animator = GetComponent<Animator>(); // grab reference for animator from object
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(currentHealth);

        //inputGetAxis horizontal A ger värde som närmar sig -1 och D värde som närmar sig +1, används ist för if else.
        float horizontalInput = Input.GetAxis("Horizontal"); 


        tid += Time.deltaTime;
        
        if (currentHealth < 100)
        {
            currentHealth += (Time.deltaTime * 2);
        } 
        if (currentHealth <= 0)
        {
            GameOver();
        }

        if (tid >= 4)
        {
            tid = 0;
            FindObjectOfType<SpawnerScript>().spawnCoin(-5, 8, -2);
            FindObjectOfType<SpawnerScript>().spawnMob(10, 15, -17);

        }

        if (Stamina <= 500)
        {
            Stamina += (30 * Time.deltaTime);

        }

        textScripts.updateStamina(Stamina);
        textScripts.updateTimer(tid);


        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos); // så den inte har någon rotation (2d spel)

        //vector2 för de 2D
        if (grounded)
        {
            body.velocity = new Vector2(horizontalInput * playerSpeed, body.velocity.y); // x,y,x
        }


        // om x scale för gubben är positiv = höger, om scale e negativ kollar den vänster.
        if (horizontalInput > 0f)
        {
            transform.localScale = Vector2.one * scaleDownSize;
        }
        if (horizontalInput < 0f)
        {
            transform.localScale = new Vector2((-1 * scaleDownSize), (1 * scaleDownSize));
        }


        // movement

        if (Input.GetKey(KeyCode.LeftShift) && horizontalInput > 0 && grounded && Stamina >= 10) //getkey returns true or false. kan bara hoppa om mane grounded.
        {
            Sprint(2);
        }
        if (Input.GetKey(KeyCode.LeftShift) && horizontalInput < 0 && grounded && Stamina >= 10) //getkey returns true or false. kan bara hoppa om mane grounded.
        {
            Sprint(-2);
        }
        if (Input.GetKey(KeyCode.Space) && horizontalInput >= 0 && grounded && Stamina >= 100) //getkey returns true or false. kan bara hoppa om mane grounded.
        {
            Jump(2);
        }
        if (Input.GetKey(KeyCode.Space) && horizontalInput <= 0 && grounded && Stamina >= 100) //getkey returns true or false. kan bara hoppa om mane grounded.
        {
            Jump(-2);
        }

        if (insideShop == true)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                textScripts.hideShop();
                textScripts.enterShopText();
                insideShop = false;
                TP(0, 0);

            }
        }

        // set animator parameters (gör den antingen true eller false så den visar idle eller run).
        animator.SetBool("Run", horizontalInput != 0); // om keys not pressed horizInput kmr va 0 (då den ska va idle), om pressed antingen de kmr va -1 eller 1, alltså != 0.
        animator.SetBool("Grounded", grounded);

        ifSprinting = false;

    }

    private void Jump(int x)
    {
        if (ifSprinting)
        {
            body.velocity = new Vector2((playerSpeed * x), (playerSpeed * 1.8f));
        } // ändrar bara y (jump)
        else
        {
            body.velocity = new Vector2((body.velocity.x), (playerSpeed * 1.8f));
        }
        grounded = false;
        Stamina -= 100;
    }

    private void Sprint(int x)
    {
        ifSprinting = true;
        body.velocity = new Vector2((x * playerSpeed), body.velocity.y);
        Stamina -= 70 * Time.deltaTime;
    }


    private void TP(int x, int y)
    {
        transform.position = new Vector2(x, y);
    }

    private void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

    }
    public void addCoin()
    {
        coins += 1;
    }
    private void GameOver()
    {
        FindObjectOfType<CSV>().importCoins(coins);
        FindObjectOfType<CSV>().writeCSV();
        textScripts.showGameover();
    }


    //to know when player is colldes with object. 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            print("grounded");
            grounded = true;
        }

        // denna funka bara under collision inte triggerenter
        if (collision.gameObject.tag == "mob1") 
        {
            print("collided with mob");
            takeDamage(40);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "coin")
        {
            coins += 1;
            textScripts.coinNumberRN(coins);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "testTag")
        {
            Stamina = 0;
            print("Stamina Reset!");
        }
        if (collision.gameObject.tag == "addStamina")
        {
            if (Stamina < 400)
            {
                Stamina += 100;
                print("Stamina Added!");
            }
        }
        //Debug.Log("Trigger!");


        if (collision.gameObject.name == "level1entry")
        {
            TP(0, -18);
        }

        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shopBuilding")
        {
            textScripts.showShop();
            if (Input.GetKey(KeyCode.E))
            {
                insideShop = true;
                grounded = false;
                TP(-15, 26);
                textScripts.insideShopText();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "shopBuilding")
        {
            if (insideShop == false)
            {
                textScripts.hideShop();
            }
        }
    }

    void OnMouseDown()
    {
        if (gameObject) // vrf funkar de inte för gameObject.name och .tag?!
        {
            coins -= 1;
            textScripts.coinNumberRN(coins);
        }
        if (gameObject.tag == "coin")
        {
            Destroy(gameObject);
        }
    }
}
