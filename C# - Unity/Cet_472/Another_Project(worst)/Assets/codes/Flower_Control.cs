using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Control : MonoBehaviour {

    public int count;

    public GameObject currect;
    public GameObject next;
   


    // Use this for initialization
    void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
    }
    public void Quit()
    {
        Application.Quit();
    }
}
