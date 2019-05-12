using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class general_cim : MonoBehaviour {
    public int carbon1 = 0;
    public int oksijen1 = 0;
    public int su1 = 0;
    public int toprak1 = 0;
    public int temp1 = 0;
    public int light1 = 0;


   
    

    bool complete = false;



    public GameObject plant;
    public GameObject plant_non;

   

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
    

    public void cim()
    {

        if (oksijen1 % 2 == 1 && su1 % 2 == 1 && temp1 % 2 == 0)
        {
            plant.GetComponent<Animator>().Play("Cim_1");
            complete = true;
        }
        else
        {
            warning.SetActive(true);
            StartCoroutine(WaitandPrint(3));
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

    public void change_carbon()
    {
        carbon1++;
    }

    public void change_oksijen()
    {
        oksijen1++;
    }

    public void change_water()
    {
        su1++;
    }
    public void change_temp()
    {
        temp1++;
    }
    public void change_torpak()
    {
        toprak1++;
    }
   



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }
}
