using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    private Scene scene;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
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

    public void GameOver()
    {
        gameOver = true;
        //Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        
    }

    public void Restart()
    {
        Debug.Log("Restart triggered");
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }
}
