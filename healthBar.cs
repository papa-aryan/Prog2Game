using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Slider slider;

    // ändrar value på slider så om health e 100 dene full 50 dend halv etc    
    public void setHealth(float health)
    {
        slider.value = health;
    }
}
