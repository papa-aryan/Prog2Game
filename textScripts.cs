using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class textScripts : MonoBehaviour
{
    // h�mta alla game objects
    public GameObject staminaCounter;
    public GameObject enterExitShop;
    public GameObject coinCounter;
    public GameObject timer;
    public GameObject gameover;

    //private string enterShopText;
    private string staminaNumber;
    private int coinNumber;
    
    // "ta ut" deras components s� man kan anv�nda de
    TextMeshProUGUI staminaCounterComponent;
    TextMeshProUGUI enterExitShopTextComponent;
    TextMeshProUGUI coinText;
    TextMeshProUGUI timerComponent;
    Image gameoverImage;

    void Start()
    {

        staminaCounterComponent = staminaCounter.GetComponent<TextMeshProUGUI>();
        enterExitShopTextComponent = enterExitShop.GetComponent<TextMeshProUGUI>();
        coinText = coinCounter.GetComponent<TextMeshProUGUI>();
        timerComponent = timer.GetComponent<TextMeshProUGUI>();
        gameoverImage = gameover.GetComponent<Image>();


        // staminaCounterComponent.enabled = false

        staminaCounterComponent.enabled = true;

        enterExitShopTextComponent.enabled = false;

        gameoverImage.enabled = false;


    }

    void Update()
    {
        staminaCounterComponent.text = staminaNumber;

        coinText.text = (": " + coinNumber);
    }

    public void updateStamina(float staminaINT)
    {

        staminaNumber = ("Stamina " + (int)staminaINT);
        
    }

    public void showShop()
    {
        enterExitShopTextComponent.enabled = true;
    }

    public void enterShopText()
    {
        enterExitShopTextComponent.text = "Press E to Enter the Shop";
    }
    public void insideShopText()
    {
        enterExitShopTextComponent.text = "Press Q to Exit the Shop";
    }
    public void hideShop()
    {
        enterExitShopTextComponent.enabled = false;
    }
    public void coinNumberRN(int num)
    {
        coinNumber = num;
    }
    public void addToCoinCounter()
    {
        coinNumber += 1;
    }
    public void updateTimer(float tid)
    {
        timerComponent.text = ("Timer: " + tid);
    }

    public void showGameover()
    {
        gameoverImage.transform.position = new Vector2(0, 0);
        gameoverImage.enabled = true;
    }

}
