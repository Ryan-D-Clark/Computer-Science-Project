using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignpostController : MonoBehaviour
{
    public bool dialogStatus;
    public GameObject dialogBox;
    public GameObject prompt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogStatus)
        {
            Time.timeScale = 0;
            prompt.SetActive(false);
            dialogBox.SetActive(true);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
        dialogStatus = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        dialogStatus = false;
        dialogBox.SetActive(false);
    }

    public void Back()
    {
        Time.timeScale = 1;
        prompt.SetActive(false);
        dialogStatus = false;
        dialogBox.SetActive(false);
    }


}
