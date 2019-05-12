using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cimlendirme : MonoBehaviour {

    public bool cimlenme;
    public GameObject plant_non;
    public GameObject plant;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


   public void correct()
    {
        cimlenme = true;
    }

    public void incorrect()
    {
        cimlenme = false;
    }

    public void check()
    {
        if(cimlenme)
        {
            plant.SetActive(true);
            plant_non.SetActive(false);
        }
    }




}
