using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabla1 : MonoBehaviour
{
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;
    Vector3 scale;
    GameObject col;

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
            this.transform.localScale = scale;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            yaprak_control.tabla+=1;
            yaprak_control.metinCounter += 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "tabla" == collision.gameObject.tag)
        {
            scale = collision.gameObject.transform.localScale;
            
            lastpos = collision.gameObject.transform.position;
            col = collision.gameObject;
            if (yaprak_control.metinCounter == 8)
            {
                correctMatch = true;
            }
            
            


        }
        else
        {
            correctMatch = false;
        }
        isInside = true;
        yaprak_control.metinCounter += 1;

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
        

    }
}
