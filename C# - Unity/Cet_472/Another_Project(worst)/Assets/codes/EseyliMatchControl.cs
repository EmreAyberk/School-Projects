using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EseyliMatchControl : MonoBehaviour
{
    public GameObject[] Types;
    public GameObject[] MemeliChecks;//0
    public GameObject[] KusChecks;//1
    public GameObject[] KurbagaChecks;//2
    public GameObject[] SurungenChecks;//3
    public GameObject[] BalikChecks;//4

    private GameObject[,] Checks = new GameObject[4,5];
    public GameObject[] EseyliCanlilar;

    public Sprite UncheckSprite;
    public Sprite CheckSprite;

    public GameObject notepadButton;
    public GameObject Notepad;
    public GameObject Continue;

    private Color DoneFont;


    // Start is called before the first frame update
    void Start()
    {
        DoneFont = new Color(0, 0.690196f, 0.1215686f, 1);
        for (int i = 0; i < 4; i++)
        {   
            Checks[i,0] = MemeliChecks[i];
            Checks[i,1] = KusChecks[i];
            Checks[i,2] = KurbagaChecks[i];
            Checks[i,3] = SurungenChecks[i];
            Checks[i,4] = BalikChecks[i];
           
                
                
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        ColliderControl();
        TypesCheckMark();
        NotepadControl();
        GameWin();
        
    }
    public int ColliderCheck()
    {
        for(int i = 0; i < EseyliCanlilar.Length; i++)
        {
            if (EseyliCanlilar[i].activeInHierarchy && EseyliCanlilar[i].GetComponent<eseyli>().checkControl)
            {
                return i;

            }
        }
        return -1;
    }

    public void ColliderControl()
    {
        int colCheck = ColliderCheck();
        if (colCheck!=-1)
        {
            for (int i = 0; i < EseyliCanlilar.Length; i++)
            {
                if (i != colCheck)
                {
                    EseyliCanlilar[i].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                EseyliCanlilar[i].GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
    public void TypesCheckMark()
    {
        int insideOne = ColliderCheck();
        if (insideOne != -1)
        {
                for (int j = 0; j < Types.Length; j++)
                {
                    {
                        if (EseyliCanlilar[insideOne].GetComponent<EseyliTypes>().IcDollenme == Types[j].GetComponent<EseyliTypes>().IcDollenme)
                        {
                            Checks[0, j].GetComponent<Image>().sprite = CheckSprite;
                        }
                        else
                        {
                            Checks[0, j].GetComponent<Image>().sprite = UncheckSprite;
                        }
                    }
                    {
                        if (EseyliCanlilar[insideOne].GetComponent<EseyliTypes>().DogurarakCogalma == Types[j].GetComponent<EseyliTypes>().DogurarakCogalma)
                        {
                            Checks[1, j].GetComponent<Image>().sprite = CheckSprite;
                        }
                        else
                        {
                            Checks[1, j].GetComponent<Image>().sprite = UncheckSprite;
                        }
                    }
                    {
                        if (EseyliCanlilar[insideOne].GetComponent<EseyliTypes>().YavruBakim == Types[j].GetComponent<EseyliTypes>().YavruBakim)
                        {
                            Checks[2, j].GetComponent<Image>().sprite = CheckSprite;
                        }
                        else
                        {
                            Checks[2, j].GetComponent<Image>().sprite = UncheckSprite;
                        }
                    }
                    {
                        if (EseyliCanlilar[insideOne].GetComponent<EseyliTypes>().AkcigerSolunum == Types[j].GetComponent<EseyliTypes>().AkcigerSolunum)
                        {
                            Checks[3, j].GetComponent<Image>().sprite = CheckSprite;
                        }
                        else
                        {
                            Checks[3, j].GetComponent<Image>().sprite = UncheckSprite;
                        }
                    }
                }
        }
        else
        {
            for (int i = 0; i < MemeliChecks.Length; i++)
            {
                MemeliChecks[i].GetComponent<Image>().sprite = null;
                KusChecks[i].GetComponent<Image>().sprite = null;
                KurbagaChecks[i].GetComponent<Image>().sprite = null;
                SurungenChecks[i].GetComponent<Image>().sprite = null;
                BalikChecks[i].GetComponent<Image>().sprite = null;
            }
        }
    }
        

    public void NotepadControl()
    {
        int notepadNum = ColliderCheck();
        if (notepadNum != -1)
        {
            notepadButton.SetActive(true);
        }
        else
        {
            notepadButton.SetActive(false);
        }
    }
    public void RecordNotepad()
    {
        int notepadNum = ColliderCheck();
        Notepad.transform.GetChild(1).GetChild(notepadNum).gameObject.SetActive(true);
        EseyliCanlilar[notepadNum].transform.position = EseyliCanlilar[notepadNum].GetComponent<eseyli>().startpos;
        EseyliCanlilar[notepadNum].transform.GetChild(0).GetComponent<Text>().color = DoneFont;
    }

    public void GameWin()
    {
        int gameCount = 0;
        for (int i = 0; i < 8; i++)
        {
            if (Notepad.transform.GetChild(1).GetComponent<Notepad_Controller>().AllCorrect[i])
            {
                gameCount++;
            }
        }
        if (gameCount == 8)
        {
            Continue.SetActive(true);
        }
    }
}
