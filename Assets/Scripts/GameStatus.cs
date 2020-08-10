using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStatus : MonoBehaviour{


    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int currentScore = 0;
    [SerializeField] int oldScore = 0;
    [SerializeField] int currentLevel;

    void Start(){
        text.text = oldScore.ToString();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       if (SceneManager.GetActiveScene().buildIndex != 8)
        {
            currentLevel = SceneManager.GetActiveScene().buildIndex;
            oldScore = currentScore;
            text.text = currentScore.ToString();
        }
        else
        {
            currentScore = oldScore;
        }
    }

    public void addToScore(string type){
        int pointsPerBlockDestroyed;
        if(type == "glass") { pointsPerBlockDestroyed = 10; }
        else if(type == "regular") { pointsPerBlockDestroyed = 20; }
        else { pointsPerBlockDestroyed = 50; }
        currentScore = currentScore + pointsPerBlockDestroyed;
        text.text = currentScore.ToString();
    }
    public int getCurrentLevel()
    {
        return currentLevel;
    }
}
