using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject leftLitTorch;
    public GameObject leftUnlitTorch;
    public GameObject rightLitTorch;
    public GameObject rightUnlitTorch;
    public GameObject gate;

    public int slimesKilled;




    // Start is called before the first frame update
    void Start()
    {
        slimesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (slimesKilled == 2)
        {
            leftLitTorch.SetActive(true);
            leftUnlitTorch.SetActive(false);
        }

        if (slimesKilled == 4)
        {
            rightLitTorch.SetActive(true);
            rightUnlitTorch.SetActive(false);
            gate.SetActive(false);
        }



    }

    public void slimeUpdater(int amount)
    {
        slimesKilled += amount;
    }




}
