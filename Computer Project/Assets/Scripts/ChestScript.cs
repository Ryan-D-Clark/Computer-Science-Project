using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    public GameObject usedChest;
    public GameObject unusedChest;
    public GameObject chestUI;
    public GameObject prompt;

    public int reward;

    bool inRange;

    PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            Time.timeScale = 0;
            chestUI.SetActive(true);
            unusedChest.SetActive(false);
            usedChest.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        inRange = false;
    }

    public void Back()
    {
        Time.timeScale = 1;
        Reward();
        prompt.SetActive(false);
        inRange = false;
        chestUI.SetActive(false);
    }


    public void Reward()
    {
        playerStats.EXPGain(reward);
    }



}
