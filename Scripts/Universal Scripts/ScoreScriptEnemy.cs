using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptEnemy : MonoBehaviour
{
    public static int scoreValueEnemy = 0; 
    Text score;
    void Start()
    {
     score = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Hightest Score: " + scoreValueEnemy;
    }


}
