using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Glass : MonoBehaviour {


  

    public Text organ;
    public Text component;

    public GameObject glasspanel;

    bool organ1 = false;
    bool organ2 = false;
    bool organ3 = false;
    bool organ4 = false;
    bool organ5 = false;
    public static bool cont = false;
    public static GameObject note;
    public GameObject notepad;

    // Use this for initialization
    void Start () {
        note = notepad;
	}
	
	// Update is called once per frame
	void Update () {

        if(organ1 && organ2 && organ3 && organ4 && organ5)
        {
            note.SetActive(true);
            
        }
       
	}

   
   


  
public void Mouth()
            {
        if (Text_Control.glass_count % 2 == 0)
        {
            organ.text = "Ağız";
            component.text = "Diş, Tükürük";
            organ1 = true;
        }
        else if(Text_Control.glass_count %2 == 1)
        {
            glasspanel.SetActive(true);
            StartCoroutine(WaitAndPrint(2));
        }
            }

    public void Liver()
    {
        if (Text_Control.glass_count % 2 == 0)
        {
            organ.text = "Karaciğer";
            component.text = "Safra";
            organ2 = true;
        }
        else if (Text_Control.glass_count % 2 == 1)
        {
            glasspanel.SetActive(true);
            StartCoroutine(WaitAndPrint(2));
        }
    }

    public void Stomach()
    {
        if (Text_Control.glass_count % 2 == 0)
        {
            organ.text = "Mide";
            component.text = "Mide Özsuyu, Peristaltik Hareket";
            organ3 = true;
        }
        else if (Text_Control.glass_count % 2 == 1)
        {
            glasspanel.SetActive(true);
            StartCoroutine(WaitAndPrint(2));
        }
    }

    public void Small()
    {
        if (Text_Control.glass_count % 2 == 0)
        {
            organ.text = "İnce Bağırsak";
            component.text = "Pankreas Özsuyu";
            organ4 = true;

        }
        else if (Text_Control.glass_count % 2 == 1)
        {
            glasspanel.SetActive(true);
            StartCoroutine(WaitAndPrint(2));
        }
    }

    public void Big()
    {
        if (Text_Control.glass_count % 2 == 0)
        {
            organ.text = "Kalın Bağırsak";
            component.text = "----";
            organ5 = true;
        }
        else if (Text_Control.glass_count % 2 == 1)
        {
            glasspanel.SetActive(true);
            StartCoroutine(WaitAndPrint(2));
        }
    }


    

    public void not()
    {
        cont = true;
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        glasspanel.SetActive(false);
    }



}
