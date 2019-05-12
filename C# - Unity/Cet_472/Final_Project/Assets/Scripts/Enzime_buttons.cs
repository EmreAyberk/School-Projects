using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enzime_buttons : MonoBehaviour {

    public GameObject carb;
    public GameObject carb_phy;
    public GameObject carb_chem;
    public GameObject oil;
    public GameObject oil_phy;
    public GameObject oil_chem;
    public GameObject pro;
    public GameObject pro_phy;
    public GameObject pro_chem;

	public GameObject Notepad;

	public GameObject carb_non;
    public GameObject oil_non;
    public GameObject pro_non;

	

    public GameObject Again;

    bool played=false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Enzime1()
    {


        if (!played)
        {
            Again.SetActive(false);
            StartCoroutine(WaitAndPrint(5));

            carb.GetComponent<Animator>().Play("carb_big");
            oil.GetComponent<Animator>().Play("oil_big");
            pro.GetComponent<Animator>().Play("pro_big");

            carb_chem.GetComponent<Animator>().Play("carb_chem");
            oil_non.GetComponent<Animator>().Play("oil_big_digest");
            pro_non.GetComponent<Animator>().Play("pro_big_digest");

            played = true;
        }

    }

    public void Enzime2()
    {

        if (!played)
        {

            Again.SetActive(false);
            StartCoroutine(WaitAndPrint(6));

            carb.GetComponent<Animator>().Play("carb_big");
            oil.GetComponent<Animator>().Play("oil_big");
            pro.GetComponent<Animator>().Play("pro_big");

            carb_non.GetComponent<Animator>().Play("carb_big_digest");
            oil_non.GetComponent<Animator>().Play("oil_big_digest");
            pro_chem.GetComponent<Animator>().Play("pro_chem");

            played = true;
        }

    }
    public void Enzime3()
    {

        if (!played)
        {
            Again.SetActive(false);
            StartCoroutine(WaitAndPrint(6));

            carb.GetComponent<Animator>().Play("carb_big");
            oil.GetComponent<Animator>().Play("oil_big");
            pro.GetComponent<Animator>().Play("pro_big");


            carb_chem.GetComponent<Animator>().Play("carb_chem");
            oil_chem.GetComponent<Animator>().Play("oil_chem");
            pro_chem.GetComponent<Animator>().Play("pro_chem");

            played = true;
        }
    }
    public void Enzime4()
    {

        if (!played)

        {

            Again.SetActive(false);
            StartCoroutine(WaitAndPrint(6));


            carb.GetComponent<Animator>().Play("carb_big");
            oil.GetComponent<Animator>().Play("oil_big");
            pro.GetComponent<Animator>().Play("pro_big");


            carb_non.GetComponent<Animator>().Play("carb_big_digest");
            oil_phy.GetComponent<Animator>().Play("oil_phy");
            pro_non.GetComponent<Animator>().Play("pro_big_digest");

            played = true;
        }

    }

    public void StartOver()
    {
        Again.SetActive(false);

        carb.GetComponent<Animator>().Play("New State");
        oil.GetComponent<Animator>().Play("New State");
        pro.GetComponent<Animator>().Play("New State");

        carb_non.GetComponent<Animator>().Play("New State");
        oil_non.GetComponent<Animator>().Play("New State");
        pro_non.GetComponent<Animator>().Play("New State");

        carb_chem.GetComponent<Animator>().Play("New State");
        oil_chem.GetComponent<Animator>().Play("New State");
        pro_chem.GetComponent<Animator>().Play("New State");

        carb_phy.GetComponent<Animator>().Play("New State");
        oil_phy.GetComponent<Animator>().Play("New State");
        pro_phy.GetComponent<Animator>().Play("New State");

        played = false;
    }


    private IEnumerator WaitAndPrint(float waitTime)
    {
       
            yield return new     WaitForSeconds(waitTime);

        Again.SetActive(true);
    }

}
