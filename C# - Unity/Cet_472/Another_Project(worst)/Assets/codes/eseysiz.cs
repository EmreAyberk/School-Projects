using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eseysiz : MonoBehaviour {
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;
    Transform rend;
    private int yIndex;
    public GameObject node1;
    public GameObject node2;
    public GameObject node3;
    public GameObject node4;
    public GameObject node5;



    // Use this for initialization
    void Start()
    {
        startpos = this.transform.position;
        rend = this.GetComponent<Transform>();
        yIndex = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScaleDown()
    {
        for(float f=1f; f>=0.06f; f -= 0.05f)
        {
            rend.localScale = new Vector3(f,f,f);
        }
        yield return new WaitForSeconds(2000f);
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
            
            
            if (this.name == "amip")
            {
                this.GetComponent<Animator>().Play("amip");
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.position = node1.transform.position;
                eseysiz_control.b1 = true;
            }
            else if (this.name == "jellyfish")
            {
                this.GetComponent<Animator>().Play("jelly");
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.position = node2.transform.position;
                eseysiz_control.b2 = true;
            }
            else if (this.name == "mush")
            {
                this.GetComponent<Animator>().Play("mush");
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.position = node3.transform.position;
                eseysiz_control.b3 = true;
            }
            else if (this.name == "star")
            {
                this.GetComponent<Animator>().Play("sar");
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.position = node4.transform.position;
                eseysiz_control.b4 = true;
            }
            else if (this.name == "potato")
            {
                this.GetComponent<Animator>().Play("potato");
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.position = node5.transform.position;
                eseysiz_control.b5 = true;
            }
            //this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "basket" == collision.gameObject.tag)
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
    }
}
