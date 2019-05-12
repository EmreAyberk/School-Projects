using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ1 : MonoBehaviour
{
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;
    Vector3 scale;
    GameObject col;
    private string organType;

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

            if (this.tag == "dişi")
            {
                yaprak_control.disi++;
                yaprak_control.metinCounter += 1;

                Debug.Log(yaprak_control.disi);
                Debug.Log(yaprak_control.metinCounter);
            }
            else if (this.tag == "erkek")
            {
                yaprak_control.erkek++;
                yaprak_control.metinCounter += 1;

                Debug.Log(yaprak_control.erkek);
                Debug.Log(yaprak_control.metinCounter);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "organ" == collision.gameObject.tag)
        {
            scale = collision.gameObject.transform.localScale;
            
            lastpos = collision.gameObject.transform.position;
            col = collision.gameObject;

            organType = this.tag;
           
            if((organType=="dişi" && yaprak_control.metinCounter == 0)|| (organType == "erkek" && (yaprak_control.metinCounter == 1 || yaprak_control.metinCounter == 2)))
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
        organType = null;
        

    }
}
