using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oksijen_cim : MonoBehaviour
{

    public bool cim=false;
    public GameObject plant_non;
    public GameObject plant;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void correct()
    {
        cim = true;
    }

    public void incorrect()
    {
        cim = false;
    }

    public void check()
    {
        if (cim)
        {
            plant.SetActive(true);
            plant_non.SetActive(false);
        }
    }




}
