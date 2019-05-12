using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startfish : MonoBehaviour {
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Animator Left_Side;
    public GameObject button;


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
        if (!isInside)
        {
            this.transform.position = startpos;
        }

        else
        {
            this.transform.position = lastpos;

            this.GetComponent<Animator>().Play("s_fish1");
            Left_Side.Play("s_fish2");
            button.SetActive(true);
            //this.gameObject.SetActive(false);
            //star1.SetActive(false);
            //star2.SetActive(true);
            //star3.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.tag + "fish" == collision.gameObject.tag)
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
