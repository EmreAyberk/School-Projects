using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

    public GameObject mush1;
    public GameObject mush2;
    public GameObject target1;
    public GameObject target2;
  

    Vector3 direction1;
    Vector3 direction2;
    bool done = false;


    // Use this for initialization
    void Start () {
        direction1 = target1.transform.position - mush1.transform.position;
        direction2 = target2.transform.position - mush2.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(done)
        {
            mush1.transform.Translate(direction1.normalized *0.5f* Time.deltaTime, Space.World);
            mush2.transform.Translate(direction2.normalized *0.5f* Time.deltaTime, Space.World);

            StartCoroutine(wait(3));
        }
	}
    public void mushroom()
    {
        mush1.SetActive(true);
        mush2.SetActive(true);
        done = true;
       
    }
    IEnumerator wait(float x)
    {
        yield return new WaitForSeconds(x);
        mush1.SetActive(false);
        mush2.SetActive(false);
    }
}
