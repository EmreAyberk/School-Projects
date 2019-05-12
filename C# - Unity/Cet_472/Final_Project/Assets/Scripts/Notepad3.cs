using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notepad3 : MonoBehaviour {

    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Dropdown dropdown3;
    public Dropdown dropdown4;
    public Dropdown dropdown5;
    public Dropdown dropdown6;
    public Dropdown dropdown7;
    public Dropdown dropdown8;
    public Dropdown dropdown9;
    public Dropdown dropdown10;
    public Dropdown dropdown11;
    public Dropdown dropdown12;


    public GameObject correct1;
    public GameObject uncorrect1;
    public GameObject correct2;
    public GameObject uncorrect2;
    public GameObject correct3;
    public GameObject uncorrect3;
    public GameObject correct4;
    public GameObject uncorrect4;


    public GameObject exit;

	public GameObject goBack;

	public GameObject enzime2;
	public GameObject enzime3;
	public GameObject enzime4;



	bool a1 = false;
    bool a2 = false;
    bool a3 = false;
    bool a4 = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

    }
    public void Control1()
    {
        if (dropdown1.value == 0 && dropdown2.value == 2 && dropdown3.value == 2)
        {
            correct1.SetActive(true);
            uncorrect1.SetActive(false);
            a1 = true;
			goBack.SetActive(true);
			enzime2.SetActive(true);
		}
        else
        {
            correct1.SetActive(false);
            uncorrect1.SetActive(true);
            a1 = false;
        }
		
    }
	public void Control2()
	{
		


		if (dropdown4.value == 2 && dropdown5.value == 2 && dropdown6.value == 0)
		{
			correct2.SetActive(true);
			uncorrect2.SetActive(false);
			a2 = true;
			goBack.SetActive(true);
			enzime3.SetActive(true);
		}
		else
		{
			correct2.SetActive(false);
			uncorrect2.SetActive(true);
			a2 = false;
		}
	}

	public void Control3()
	{

		if (dropdown7.value == 2 && dropdown8.value == 1 && dropdown9.value == 2)
		{
			correct3.SetActive(true);
			uncorrect3.SetActive(false);
			a3 = true;
			
		}
		else
		{
			correct3.SetActive(false);
			uncorrect3.SetActive(true);
			a3 = false;
		}
		if (a1 && a2 && a3 && a4)
		{
			exit.SetActive(true);
		}
	}
	public void Control4()
	{
		if (dropdown10.value == 0 && dropdown11.value == 0 && dropdown12.value == 0)
		{
			correct4.SetActive(true);
			uncorrect4.SetActive(false);
			a4 = true;
			goBack.SetActive(true);
			enzime4.SetActive(true);

		}
		else
		{
			correct4.SetActive(false);
			uncorrect4.SetActive(true);
			a4 = false;
		}


		
	}
	public void CheckControl()
	{

	}
	

}
