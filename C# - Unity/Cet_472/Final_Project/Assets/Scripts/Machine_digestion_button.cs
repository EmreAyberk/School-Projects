using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_digestion_button : MonoBehaviour {

    
    public GameObject big_one_phy;
    public GameObject big_one_chem;
    public GameObject small_one_phy;
    public GameObject small_one_chem;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void anim_physical()
    {
        big_one_phy.GetComponent<Animator>().Play("physical_digestion_button");
        small_one_phy.GetComponent<Animator>().Play("physical_digestion_button_little");
    }
    public void anim_chemical()
    {
        big_one_chem.GetComponent<Animator>().Play("chemical_digestion_button");
        small_one_chem.GetComponent<Animator>().Play("chemical_digestion_button_little");
    }
}
