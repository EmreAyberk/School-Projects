using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Second_Mission_Controller : Fade_InOut {

    public bool phys;
    public bool chem;
    public bool note_saved1;
    public bool note_saved2;
    public GameObject note1;
    public GameObject note2;

    public GameObject Digestion_Panel;
    public GameObject Enzime_Panel;


    public bool enzime1;
    public bool enzime2;
    public bool enzime3;
    public bool enzime4;

	public GameObject panel2;
	public GameObject panel3;
	public GameObject panel4;

	public GameObject goBack;

    public Text txt;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(phys && chem)
        {
            note1.SetActive(true);
        }
        
	}

    public void first_phys()
    {
        phys = true;
    }
    public void first_chem()
    {
        chem = true;
    }

    public void Note_true1()
    {
        note_saved1 = true;
    }
    public void Note_true2()
    {
        note_saved2 = true;
    }
    public void Next_panel()
    {
        if(note_saved1)
        {
            Digestion_Panel.SetActive(false);
            Enzime_Panel.SetActive(true);
            txt.text = "Yeni bir görev seni bekliyor. “Tükürük” butonuna tıklamalısın ve karbonhidrat, yağ ve protein içeren besinlerin tükürük ile sindirildikten sonra şekillerindeki değişimleri “Not Defterine Kaydet” butonuna tıklayarak defterine kaydetmelisin. Ardından diğer enzimler için de aynı işlemleri gerçekleştirmelisin.";

        }
    }

    public void Enzime_True()
    {
        if(note_saved2)
        {
            Fade(4);
        }
    }

    public void enzime_1()
    {
        enzime1 = true;
		goBack.SetActive(false);
		
	}
    public void enzime_2()
    {
        enzime2 = true;
		goBack.SetActive(false);
		panel2.SetActive(true);
    }
    public void enzime_3()
    {
        enzime3 = true;
		goBack.SetActive(false);
		panel4.SetActive(true);
	}
    public void enzime_4()
    {
        enzime4 = true;
		goBack.SetActive(false);
		panel3.SetActive(true);
	}
    
}
