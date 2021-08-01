using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIEnemy : MonoBehaviour
{
    private Image health_UI_Enemy;
     void Awake()
    {
        health_UI_Enemy = GameObject.FindWithTag(Tags.HEALTH_UI_ENEMY).GetComponent<Image>();
    }

    // Update is called once per frame
    public void DisplayHealth(float value)
    {
        value /=100f;
        if(value <0f)
            value = 0f;
            health_UI_Enemy.fillAmount = value;

   }
}

