using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingUI : MonoBehaviour
{

    public GameObject savingUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        Debug.Log("Saved");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        savingUI.SetActive(false);
    }



}
