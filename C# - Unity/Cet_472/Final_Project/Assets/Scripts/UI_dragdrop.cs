using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_dragdrop : MonoBehaviour {
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;


    public GameObject devam;


    // Use this for initialization
    void Start()
    {
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnMouseDrag()
    {
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(newpos.x, newpos.y, 0);
    }

    void OnMouseUp()
    {
        if (!correctMatch)
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
    }
}
