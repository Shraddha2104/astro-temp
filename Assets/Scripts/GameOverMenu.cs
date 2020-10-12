using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    public Text scoreText;
    bool toggle = false;
    private float transitionAlpha = 0;

    public Image backgroundImg;
    public float maxTrasitionAlpha;

    // Use this for initialization
    void Start ()
    {
        gameObject.SetActive(false);
        toggle = false;
        transitionAlpha = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (toggle)
        {
            if(transitionAlpha < maxTrasitionAlpha)
                transitionAlpha += Time.deltaTime;
            backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, transitionAlpha), transitionAlpha);
        }
		
	}

    public void ToggleGameOverMenu(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString();
        toggle = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameMaster gmScript = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    public void GoToTitleMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
