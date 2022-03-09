using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {


    public GameObject MainMenu;
    public GameObject HelpMenu;
    public GameObject LoadGame;

	// Use this for initialization
	void Update ()
    {
        if (System.IO.File.Exists("Statistics.xml"))
        {
            LoadGame.SetActive(true);
        }
    }
	

    public void New()
    {
        SceneManager.LoadScene("House");
        if (System.IO.File.Exists("Statistics.xml"))
        {
            Saving();
        }
        else
        {
            Saving();
        }
    }
    public void Load()
    {
        SceneManager.LoadScene("House");
    }
    public void Help()
    {
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        MainMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }

    static void Saving()
    {

        Stats stats = new Stats();
        stats.CurrentExp = 0;
        stats.PlayerLevel = 1;
        stats.Save("Statistics.xml");
    }


}
