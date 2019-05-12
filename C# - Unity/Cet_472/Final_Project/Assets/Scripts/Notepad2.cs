using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notepad2 : MonoBehaviour {

    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;

    public GameObject correct1;
    public GameObject uncorrect1;
    public GameObject correct2;
    public GameObject uncorrect2;

    public GameObject physical;

    public GameObject chemical;

    public GameObject exit;



    bool a1 = false;
    bool a2 = false;
   


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void Control()
    {
        if (dropdown1.value == 0 && dropdown2.value == 1)
        {
            correct1.SetActive(true);
            uncorrect1.SetActive(false);
            a1 = true;
        }
        else
        {
            correct1.SetActive(false);
            uncorrect1.SetActive(true);
            a1 = false;
        }

        if (dropdown3.value == 0 && dropdown4.value == 1)
        {
            correct2.SetActive(true);
            uncorrect2.SetActive(false);
            a2 = true;
        }
        else
        {
            correct2.SetActive(false);
            uncorrect2.SetActive(true);
            a2 = false;
        }


        if (a1 && a2)
        {
            exit.SetActive(true);
            physical.SetActive(true);
            chemical.SetActive(true);
        }
        else
        {
            exit.SetActive(false);
            physical.SetActive(false);
            chemical.SetActive(false);
        }
    }
}
