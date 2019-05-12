using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marti : MonoBehaviour
{

    Vector3 startposition;
    public bool isinside = false;
    public GameObject panel;


    // Use this for initialization
    void Start()
    {

        startposition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isinside)
        {
            panel.SetActive(false);
        }

    }
    void OnMouseDown()
    {

    }
    void OnMouseDrag()
    {
        Vector3 newpos = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        this.transform.position = new Vector3(newpos.x, newpos.y, 0);
    }
    void OnMouseUp()
    {
        if (!isinside)
        {
            this.transform.position = startposition;
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.tag + "b" == col.gameObject.tag)
        {
            isinside = true;

        }
        else
        {
            isinside = false;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        isinside = false;

    }


}
