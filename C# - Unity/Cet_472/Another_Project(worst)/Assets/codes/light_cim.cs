using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_cim : MonoBehaviour {
    public int light1 = 0;
    public int light2 = 0;


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

    public GameObject notepad_p1;



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

        if ((light1 % 2) != (light2 % 2))
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
            
            
                plant.GetComponent<Animator>().Play("Light_1");
                plant1.GetComponent<Animator>().Play("Light_2");
            //plant_non.SetActive(false);



            //plant1.SetActive(true);
            //plant_non1.SetActive(false);

            notepad_p1.SetActive(true);
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

    public void change_light1()
    {
        light1++;
    }

    public void change_light2()
    {
        light2++;
    }



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }

}
