using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour {


    public Text final;
    public GameObject finaltxt;


	// Use this for initialization
	void Start () {
        final.text = "Kazanan:    Asistan   " + Name.player_name;
        StartCoroutine(WaitAndPrint(3));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        finaltxt.SetActive(true);

    }
}
