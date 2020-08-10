using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    [SerializeField] AudioClip audioClip;
    Level level;
    int health;
    string type;


    private void Start(){
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        if(gameObject.tag == "BrokenBlock") {
            health = 1;
            type = "glass";
        }
        else if(gameObject.tag == "RegularBlock") {
            health = 2;
            type = "regular";
        }
        else{
            health = 5; // big block has health of 5 so that is how many times you need to hit it before it is destroyed
            type = "big";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        health--;
        if(health == 0){
            FindObjectOfType<GameStatus>().addToScore(type);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 0.1f);
            level.BlockDestroyed();
        }
    }

}
