using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour {

    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;
    

    // Use this for initialization
    void Start () {
        startpos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    void OnMouseDrag()
    {
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(newpos.x, newpos.y, 0);
    }

    void OnMouseUp()
    {
        if (!isInside)
        {
            this.transform.position = startpos;
        }
        
        else
        {
            this.transform.position = lastpos;
            correct++;           
           
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "Organ" == collision.gameObject.tag)
        {
            correctMatch = true;
            lastpos = collision.gameObject.transform.position;
            if (this.tag == "1")
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                this.GetComponent<PolygonCollider2D>().enabled = false;

            }

        }
        else
        {
            correctMatch = false;
        }
        isInside = true;

       
       
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
		correctMatch = false;
        if (this.tag == "1")
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;

        }
    }
}

