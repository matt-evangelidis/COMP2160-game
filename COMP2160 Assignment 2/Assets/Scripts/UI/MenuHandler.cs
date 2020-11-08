using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public string winMessage = "You Win!";
    public string loseMessage = "You Died!";

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
        //get checkpoint manager
        manager = FindObjectOfType<CheckpointManager>();

        //get GameOver textfields
        gameOverText = gameOverMenu.transform.Find("Game Over Text").GetComponent<Text>();
        Debug.Log(gameOverText.text.ToString());

        gameOverList = gameOverMenu.transform.Find("Game Over List").GetComponent<Text>();
        Debug.Log(gameOverList.text.ToString());

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);

        //get scene reference for restarting
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //pause menu functionality
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
        //get the checkpoints from the CheckPointManager
        Checkpoint[] array = manager.ReturnCheckpoints();

        if (dead)
        {
            ProcessGameOverUI(loseMessage, array);
        }
        else
        {
            ProcessGameOverUI(winMessage, array);
        } 
    }

    private void ProcessGameOverUI(string message, Checkpoint[] array)
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);

        //set "You Win!" or "You Died!"
        gameOverText.text = message;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Hit)
            {
                //format time stored in checkpoint
                TimeSpan timer = TimeSpan.FromSeconds(array[i].TimeStored);
                string text = string.Format("{0:D2}:{1:D2}:{2:D2}", timer.Minutes, timer.Seconds, timer.Milliseconds);

                gameOverList.text += "Checkpoint " + (i + 1) + ": " + text + Environment.NewLine;
            }

            else
            {
                gameOverList.text += "Checkpoint " + (i + 1) + ": Incomplete" + Environment.NewLine;
            }
        }
    }

    public void Restart()
    {
        Debug.Log("Restart triggered");
        SceneManager.LoadScene(scene.name);
    }
}
