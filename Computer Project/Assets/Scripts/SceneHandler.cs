using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour

{
    public string nextScene;
 

     void Update()
    {

    }



    public void OnTriggerEnter2D(Collider2D player)
    {
        SceneManager.LoadScene(nextScene);
        Saving();
    }

    static void Saving()
    {

        Stats stats = new Stats();
        stats.CurrentExp = PlayerStats.sCurrentExp;
        stats.PlayerLevel = PlayerStats.sPlayerLevel;
        stats.Save("Statistics.xml");
    }





}

