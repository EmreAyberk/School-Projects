using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notepad_Controller : MonoBehaviour
{
    public Dropdown timsah;
    public Dropdown kedi;
    public Dropdown fare;
    public Dropdown yarasa;
    public Dropdown papagan;
    public Dropdown balik;
    public Dropdown kurbaga;
    public Dropdown balina;


    /*
    public GameObject timsahPanel;
    public GameObject kediPanel;
    public GameObject farePanel;
    public GameObject yarasaPanel;
    public GameObject papaganPanel;
    public GameObject balikPanel;
    public GameObject kurbagaPanel;
    public GameObject balinaPanel;
    */

    public GameObject[] Panels;

 

    string[] CanliType;
    public bool[] AllCorrect;

    // Start is called before the first frame update
    void Start()
    {
        CanliType = new string[5];

        CanliType[0] = "memeli";
        CanliType[1] = "kus";
        CanliType[2] = "kurbaga";
        CanliType[3] = "balik";
        CanliType[4] = "surungen";

    }

    // Update is called once per frame
    void Update()
    {
        CloseAllText();
    }

    public void CloseAllText()
    {
        for (int i = 0; i < 8; i++)
        {
            if(Panels[i].transform.GetChild(1).GetComponent<Dropdown>().value !=0)
            {
                Panels[i].transform.GetChild(Panels[i].transform.GetChild(1).GetComponent<Dropdown>().value + 1).gameObject.SetActive(true);
                for (int j = 2; j < 7; j++)
                {
                    if(j != Panels[i].transform.GetChild(1).GetComponent<Dropdown>().value + 1)
                    {
                        Panels[i].transform.GetChild(j).gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    public void ControlTypes()
    {
        for (int i = 0; i < 8; i++)
        {
            if(Panels[i].gameObject.activeInHierarchy == true && Panels[i].transform.GetChild(1).GetComponent<Dropdown>().value != 0)
            {
                if (CanliType[Panels[i].transform.GetChild(1).GetComponent<Dropdown>().value - 1] == Panels[i].transform.GetChild(0).transform.tag)
                {
                    Panels[i].gameObject.GetComponent<Image>().color = new Color(0.72f, 1, 0.768f, 1);
                    AllCorrect[i] = true;
                }
                else
                {
                    Panels[i].gameObject.GetComponent<Image>().color = new Color(1, 0.5254f, 0.5529f, 1);
                    AllCorrect[i] = false;
                }
            }
            
        }
    }
}
