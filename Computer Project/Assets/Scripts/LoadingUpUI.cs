﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUpUI : MonoBehaviour
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        savingUI.SetActive(true);
    }

}
