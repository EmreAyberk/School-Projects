using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carbon_cim : MonoBehaviour {

    public int carbon1 = 0;
    public int carbon2 = 0;


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

    public GameObject notepad_p2;

   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        
	}
    public void btn_control()
    {

        if ((carbon1 % 2) != (carbon2 % 2))
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
        if(cimlendir)
        {

            plant.GetComponent<Animator>().Play("Carbon_1");
            plant1.GetComponent<Animator>().Play("Carbon_2");

            notepad_p2.SetActive(true);
            complete = true;
        }
    }
    public void done()
    {
        if(complete)
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

    public void  change_carbon1()
    {
        carbon1++;
    }

    public void change_carbon2()
    {
        carbon2++;
    }



    IEnumerator WaitandPrint(float time)
    {
        yield return new WaitForSeconds(time);

        warning.SetActive(false);
    }
}
