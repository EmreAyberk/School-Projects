using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulasyon_cim : MonoBehaviour
{

    public bool cim=false;
    public GameObject plant_non;
    public GameObject plant;
    public bool su = false;
    public bool oksijen = false;
    public bool sıcaklık = false;
    public bool isik = false;
    public bool karbon = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void su_correct()
    {
        su = true;
    }
    public void su_incorrect()
    {
        su = false;
    }

    public void oksijen_correct()
    {
        oksijen = true;
    }
    public void oksijen_incorrect()
    {
        oksijen = false;
    }

    public void sıcaklık_correct()
    {
        sıcaklık = true;
    }
    public void sıcaklık_incorrect()
    {
        sıcaklık = false;
    }

    public void isik_correct()
    {
        isik= true;
    }
    public void isik_incorrect()
    {
        isik = false;
    }


    public void karbon_correct()
    {
        karbon = true;
    }
    public void karbon_incorrect()
    {
        karbon = false;
    }

    public void correct()
    {
        if (isik && su && oksijen)
        {
            cim = true;
        }
        else
        {
            cim = false;
        }
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
