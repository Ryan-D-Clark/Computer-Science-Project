using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerStats : MonoBehaviour
{
    public int playerLevel;
    public static int sPlayerLevel;
    private int maximumLevel;
    public Text levelText;

    public Text currentHealthText;
    public int currentHealth;

    public Text maxtHealthText;
    public int maxHealth;

    public Text currentExpText;
    public int currentExp;
    public static int sCurrentExp;

    public Text requiredExpText;
    public int requiredExp;

    public int attackPoints;

    DeathScreen deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        Stats stats = Stats.LoadFile("Statistics.xml");

        playerLevel = stats.PlayerLevel;
        maximumLevel = 10;
        currentHealth = ((playerLevel * 30) + 30);
        currentExp = stats.CurrentExp;
        deathScreen = GetComponent<DeathScreen>();

    }

    // Update is called once per frame
    void Update()
    {
        attackPoints = (4 + (playerLevel * 2)); 


        sCurrentExp = currentExp;
        sPlayerLevel = playerLevel;


        levelText.text = playerLevel.ToString();
        currentHealthText.text = currentHealth.ToString();
        maxtHealthText.text = maxHealth.ToString();
        currentExpText.text = currentExp.ToString();
        requiredExpText.text = requiredExp.ToString();
        requiredExp = ((playerLevel * 50) + 50);
        maxHealth = ((playerLevel * 30) + 30);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentExp += 30;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentHealth -= 30;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Saving();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Stats.LoadFile("Statistics.xml");
        }
        if (currentExp >= requiredExp)
        {
            currentExp = 0;
            playerLevel += 1;
            currentHealth = ((playerLevel * 30) + 30);
        }
        if (playerLevel == maximumLevel)
        {
            currentExp = 0;
            requiredExp = 0;
        }

        if(currentHealth <= 0)
        {
            deathScreen.GameOver();
        }




    }
    static void Saving()
    {

        Stats stats = new Stats();
        stats.CurrentExp = sCurrentExp;
        stats.PlayerLevel = sPlayerLevel;
        stats.Save("Statistics.xml");
    }

    public void EXPGain(int EXPReward)
    {
        currentExp += EXPReward;
    }

    public void TakeDamage(int enemyDamage)
    {
        currentHealth -= enemyDamage;
    }


}