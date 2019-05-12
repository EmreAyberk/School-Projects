using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gender_Controller : Fade_InOut {

    public static int gender = 0;

    public GameObject gender_panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void boy()
    {
        gender = 1;
    }
    public void girl()
    {
        gender = 2;
    }

    public void Continue2()
    {
        if (gender != 0)
        {
            Fade(2);
        }
        else if(gender==0)
        {
            gender_panel.SetActive(true);
            StartCoroutine(WaitAndPrint(3));
        }
    }


    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        gender_panel.SetActive(false);
    }
}
