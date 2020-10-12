using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    //public static float rMin = 1;

    private int score = 0;
    private bool gameOver;
    private GameObject[] tiles;

    private GameObject player;

    public float[] values = new float[6];

    public Text scoreText;

    public float difficultyModifier;

    public GameOverMenu gom;

    // Use this for initialization
    public void Start ()
    {
        score = 0;
        values[0] = 0f;
        values[1] = 0.1f;
        values[2] = 0f;
        values[3] = 0.7f;
        values[4] = 0.4f;
        values[5] = 1f;

        gameOver = false;
        
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameOver)
        {
            OnGameOver();
        }
    }

    public void RecolorTiles()
    {
        tiles = GameObject.FindGameObjectsWithTag("Respawn");
        values = new float[6];

        int domiantColor = (int)UnityEngine.Random.Range(0, 5.999f);

        values[0] = UnityEngine.Random.Range(0f, values[domiantColor]);
        values[1] = UnityEngine.Random.Range(values[0], 1f);
        values[2] = UnityEngine.Random.Range(0f, values[domiantColor]);
        values[3] = UnityEngine.Random.Range(values[2], 1f);
        values[4] = UnityEngine.Random.Range(0f, values[domiantColor]);
        values[5] = UnityEngine.Random.Range(values[4], 1f);
    }

    public void IncreamentScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        if (score % 100 == 0 && score != 0)
        {
            RecolorTiles();
            SetDifficulty();
        }
    }

    private void SetDifficulty()
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.SetSpeed(pc.GetSpeed() + difficultyModifier);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void SetGameOver( bool over)
    {
        gameOver = over;
    }

    private void OnGameOver()
    {
        gom.ToggleGameOverMenu(score);
    }
}
