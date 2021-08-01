using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpGame : MonoBehaviour
{
    public static int scoreValueLevel = 1;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
          score.text = "LEVEL : " + scoreValueLevel;
    }
}
