using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour {
    Vector3 startpos;
    public bool isInside;
    public bool correctMatch;
    Vector3 lastpos;
    public static int correct;
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
            this.GetComponent<Animator>().Play(this.name);
            button.SetActive(true);
            this.transform.Rotate(new Vector3(0, 0, -35));
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
