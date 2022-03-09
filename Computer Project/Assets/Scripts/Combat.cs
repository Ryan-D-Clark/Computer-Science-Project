using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public int EXPReward;

    public int enemyDamage;

    public bool dead;
    public bool notLoaded;

    PlayerStats playerValues;
    Scene currentScene;
    GateController gate;

	// Use this for initialization
	void Start ()
    {
        playerValues = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        currentScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update ()
    {
        EXPReward = (playerValues.requiredExp/9) - playerValues.playerLevel;
        maxHealth = playerValues.playerLevel * 5 + 15;
        enemyDamage = playerValues.playerLevel * 5 + 3;

        if(notLoaded == false)
        {
            CreatingStats();
        }

        if(health <= 0)
        {
            dead = true;

            if(currentScene.name == "Cave")
            {
                gate = GameObject.FindGameObjectWithTag("Gate").GetComponent<GateController>();
                gate.slimeUpdater(1);
            }
        }


    }

    void CreatingStats()
    {
        notLoaded = true;
        health = maxHealth;
    }

    public void TakeDamage(int playerDamage)
    {
        health -= playerDamage;
    }



}
