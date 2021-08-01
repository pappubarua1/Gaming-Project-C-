using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public static float  health = 100f;
    public  static float healthEnemy = 100f;

    private CharacterAnimation animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;
    public bool is_Enemy;

    private HealthUI health_UI;
    private HealthUIEnemy health_UI_Enemy;
    public GameObject pausePanel;


    void Awake(){
        animationScript = GetComponentInChildren<CharacterAnimation>();
        
        if(is_Player){
        health_UI = GetComponent<HealthUI>();
    }
    if(is_Enemy){
        health_UI_Enemy = GetComponent<HealthUIEnemy>();
    }
}

    public void Resume(){
         pausePanel.SetActive(false);
         Time.timeScale = 1f;
         HighestScoreScript.highScoreValue = ScoreScript.scoreValue;
         HighestScoreEnemyScript.highScoreValueEnemy = ScoreScriptEnemy.scoreValueEnemy;

    }
     public void Pause(){
         pausePanel.SetActive(true);
        Time.timeScale= 0f;
        
    }
    public void QuitGame(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


   public void ApplyDamage(float damage, bool KnockDown){
       if(characterDied)
        return;

    health -=damage;
    healthEnemy-=damage;
    //display health UI;
    if(is_Player){
    ScoreScriptEnemy.scoreValueEnemy +=10;
    health_UI.DisplayHealth(health);
    }

    if(is_Enemy){
        ScoreScript.scoreValue += 10;
        health_UI_Enemy.DisplayHealth(healthEnemy);
    }

    if(health<=0f) { //if is player deactivate enemy script
        animationScript.Death();
        characterDied = true;
        //if is player deactivate enemy script
        if(is_Player){
            GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
            pausePanel.SetActive(true);
            Time.timeScale= 0f;
        }
        return;
    }   
    if(healthEnemy <= 0f)
    {
        animationScript.Death();
        characterDied = true;
        pausePanel.SetActive(true);
        Time.timeScale= 0f;
        LevelUpGame.scoreValueLevel +=1;
        healthEnemy = 100f;
    }
    if(!is_Player){
        if(KnockDown){
            if(Random.Range(0,2)>0){
                animationScript.KnockDown();
            }
        } else{
            if(Random.Range(0,3)>1){
                animationScript.Hit();
            }
        }

    }//if is player


   }//apply damage


}//class






