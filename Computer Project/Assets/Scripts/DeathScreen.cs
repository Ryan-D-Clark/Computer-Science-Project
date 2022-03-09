using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public GameObject canvas;
    public GameObject deathScreen;
    PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        canvas.SetActive(false);
        deathScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Stats stats = new Stats();
        stats.CurrentExp = playerStats.currentExp;
        stats.PlayerLevel = playerStats.playerLevel;
        stats.Save("Statistics.xml");
        SceneManager.LoadScene("House");
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
        Stats stats = new Stats();
        stats.CurrentExp = playerStats.currentExp;
        stats.PlayerLevel = playerStats.playerLevel;
        stats.Save("Statistics.xml");
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Stats stats = new Stats();
        stats.CurrentExp = playerStats.currentExp;
        stats.PlayerLevel = playerStats.playerLevel;
        stats.Save("Statistics.xml");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

}
