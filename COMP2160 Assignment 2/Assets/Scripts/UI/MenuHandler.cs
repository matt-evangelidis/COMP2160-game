using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public CheckpointManager manager;
    private Text gameOverText;
    private Text gameOverList;
    private Scene scene;

    private bool gameOver = false;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        gameOverText = gameOverMenu.transform.Find("Game Over Text").GetComponent<Text>();
        Debug.Log(gameOverText.text.ToString());

        gameOverList = gameOverMenu.transform.Find("Game Over List").GetComponent<Text>();
        Debug.Log(gameOverList.text.ToString());

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !gameOver)
        {
            if (!pauseMenu.activeInHierarchy)
            {
                PauseGame();
            }

            else if (pauseMenu.activeInHierarchy)
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GameOver(bool dead)
    {
        if (dead)
        {
            gameOver = true;
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);

            gameOverText.text = "You Died!";

            Checkpoint[] array = manager.ReturnCheckpoints();

            foreach (Checkpoint i in array)
            {
                gameOverList.text += "Checkpoint " + i + ": " + i.TimeStored + Environment.NewLine;
            }
        }
        else
        {
            gameOver = true;
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
        
    }

    public void Restart()
    {
        Debug.Log("Restart triggered");
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }
}
