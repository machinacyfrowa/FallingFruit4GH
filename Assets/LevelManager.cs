using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sprawdz czy wsicnieto escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
        }
        scoreText.text = "Punkty: " + score.ToString();
    }
    public void AddScore(int scoreToAdd = 10)
    {
        score += scoreToAdd;
    }
}
