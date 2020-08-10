using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{

    public void changeScene(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene == 6){
            SceneManager.LoadScene(9);
        }
        else{
            SceneManager.LoadScene(currentScene + 1);
        }
        
    }
    public void mainMenu() {
        SceneManager.LoadScene(0);
    }
    public void quitGame(){
        Application.Quit();
    }
    public void retryLevel(){
        int level = FindObjectOfType<GameStatus>().getCurrentLevel();
        SceneManager.LoadScene(level);
    }
}
