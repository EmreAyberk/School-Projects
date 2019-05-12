using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oksij_cim : MonoBehaviour {
    public int oksijen1 = 0;
    public int oksijen2 = 0;


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

    public GameObject notepad_p3;


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

        if ((oksijen1 % 2) != (oksijen2 % 2))
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

            if (oksijen1 % 2 == 1)
            {
                plant.GetComponent<Animator>().Play("Oksi_1");
            }
            if (oksijen2 % 2 == 1)
            {
                plant1.GetComponent<Animator>().Play("Oksi_2");
            }
            notepad_p3.SetActive(true);
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

    public void change_oksijen1()
    {
        oksijen1++;
    }

    public void change_oksijen2()
    {
        oksijen2++;
    }



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }
}
