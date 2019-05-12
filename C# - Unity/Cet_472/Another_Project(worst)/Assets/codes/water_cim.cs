using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_cim : MonoBehaviour {


    public int su1 = 0;
    public int su2 = 0;


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

    public GameObject notepad_p4;



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

        if ((su1 % 2) != (su2 % 2))
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
            if (su1 % 2 == 1)
            {
                plant.GetComponent<Animator>().Play("Su_1");
            }
            if (su2 % 2 == 1)
            {
                plant1.GetComponent<Animator>().Play("Su_2");
            }
            notepad_p4.SetActive(true);
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
        su1++;
    }

    public void change_carbon2()
    {
        su2++;
    }



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }
}
