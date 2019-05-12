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
            if (this.tag == "dişi")
            {
                yaprak_control_light.disi++;
                yaprak_control_light.metinCounter += 1;

                Debug.Log(yaprak_control_light.disi);
                Debug.Log(yaprak_control_light.metinCounter);
            }
            else if (this.tag == "erkek")
            {
                yaprak_control_light.erkek++;
                yaprak_control_light.metinCounter += 1;

                Debug.Log(yaprak_control_light.erkek);
                Debug.Log(yaprak_control_light.metinCounter);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "organ" == collision.gameObject.tag)
        {
           
            lastpos = collision.gameObject.transform.position;

            if ((this.tag == "dişi" && yaprak_control_light.metinCounter == 0) || (this.tag == "erkek" && (yaprak_control_light.metinCounter == 4 || yaprak_control_light.metinCounter == 5)))
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
