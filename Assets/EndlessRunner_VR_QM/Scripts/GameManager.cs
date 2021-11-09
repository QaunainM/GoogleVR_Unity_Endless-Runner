﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public Player player;

    private float enemyPointer;     // Calculator for distance of player to enemy
    public float spawnDistanceFromPlayer = 20f;
    public float spawnDistanceFromEnemy = 5f;

    public TextMesh uiText;

    public float gameTimer;
    private float finalTime;
    private int finalScore;
    private bool isGamerOver = false;
    private float gameOverTimer = 4.5f;

    public GameObject finishLine;
    public float finishLinePosition = 200f;

     

    // Start is called before the first frame update
    void Start() {
        finishLine = GameObject.Find("FinishLine");   // Import the Finish Line game object 
        finishLine.transform.position = new Vector3(0,0,finishLinePosition);  // Location to place the finish line object
    }

    // Update is called once per frame
    void Update() {

        // Setting when to spawn enemies 
        if (enemyPointer < player.cameraRig.transform.position.z) {
            enemyPointer += spawnDistanceFromEnemy;

            // Dynamically Generate (spawn) enemies
            GameObject enemyObject = Instantiate(enemyPrefab);
            enemyObject.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(2.5f, 6.5f), player.cameraRig.transform.position.z + spawnDistanceFromPlayer);

        }

        gameTimer += Time.deltaTime;   // Increment the game timer 


        if (isGamerOver == false) {
            uiText.text = "Time: " + Mathf.FloorToInt(gameTimer) + "   Score: " + player.score  +  "   Speed: " + Mathf.Floor(player.speed) ;
            // UI Text to display when the player is running (Time, score and speed)
            if (player.reachedFinishLine == true) { // Change Boolean when player hits finish line and save the final time and score
                isGamerOver = true;
                finalTime = gameTimer;
                finalScore = player.score;
            }
        } else {  // What to do when the player hits the finish line
            uiText.text = "Game Over!\nTime: " + Mathf.FloorToInt(finalTime) + "   Score: " + finalScore + "\nRestarting in: " + Mathf.Floor(gameOverTimer);
            player.speed = 0.3f;  player.maxSpeed = 0.75f;

            gameOverTimer -= Time.deltaTime;    // Gamer restart logic
            if (gameOverTimer <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
        }



    }


}
