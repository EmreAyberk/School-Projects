using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabla : MonoBehaviour {
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;



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
           
            this.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);

            yaprak_control_light.tabla += 1;
            yaprak_control_light.metinCounter += 1;


        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "tabla" == collision.gameObject.tag)
        {

            lastpos = collision.gameObject.transform.position;

            if (yaprak_control_light.metinCounter == 8)
            {
                correctMatch = true;
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
    }
}
