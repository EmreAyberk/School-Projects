using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toprak_cim : MonoBehaviour {
    public int toprak1 = 0;
    public int toprak2 = 0;


    bool cimlendir = false;
    bool cimlendir1 = false;

    bool complete = false;



    public GameObject plant;
    public GameObject plant_non;

    public GameObject plant1;
    public GameObject plant_non1;

    public GameObject current_panel;
    public GameObject next_panel;

    public GameObject warning;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
    public void btn_control()
    {

        if ((toprak1 % 2) != (toprak2 % 2))
        {
            cimlendir = true;
        }

        else
        {
            warning.SetActive(true);
            StartCoroutine(WaitandPrint(3));
        }
    }

    public void cim()
    {
        if (cimlendir)
        {
           
                plant.SetActive(true);
                plant_non.SetActive(false);
          
                plant1.SetActive(true);
                plant_non1.SetActive(false);
            

            complete = true;
        }
    }
    public void done()
    {
        if (complete)
        {
            current_panel.SetActive(false);
            next_panel.SetActive(true);
        }
        else
        {
            warning.SetActive(true);
            StartCoroutine(WaitandPrint(3));
        }
    }

    public void change_carbon1()
    {
        toprak1++;
    }

    public void change_carbon2()
    {
        toprak2++;
    }



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }
}
