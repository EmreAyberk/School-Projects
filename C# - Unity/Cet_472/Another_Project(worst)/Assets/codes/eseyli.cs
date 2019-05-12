using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eseyli : MonoBehaviour {

    public Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public GameObject lastposter;
    public static int correct;

    public bool checkControl;
    public bool Controlled;



    // Use this for initialization
    void Start()
    {
        startpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == startpos)
        {
            checkControl = false;
        }
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
            checkControl = true;
            Controlled = true;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="eseyli")
        {
            correctMatch = true;
            lastpos = lastposter.gameObject.transform.position;

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
    }
}
