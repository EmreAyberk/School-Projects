using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : Fade_InOut {

    public GameObject message;
    public GameObject ShowPanel;
    public GameObject HidePanel;
    public GameObject HelpPanel;
    public Text txt;
    public GameObject secondwave;
    public GameObject devam;
    public Text mission;


    public GameObject boy;
    public GameObject girl;


    // Use this for initialization
    void Start () {
        if(Gender_Controller.gender==1)
        {
            boy.SetActive(true);
        }
        if (Gender_Controller.gender == 2)
        {
            girl.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
		if(Organ.correct==5)
        {
            message.SetActive(true);
            txt.text = "Oh! Profesör fark etmeden modeli tamamlamayı başardım. Profesörün gözüne girdiğimi düşünüyorum. Artık şu kongreden birincilikle dönüp profesörün yerine geçmenin vakti geldi.";

            StartCoroutine(WaitAndPrint(1));
        }
        if(UI_dragdrop.correct==5)
        {
            secondwave.SetActive(true);
            mission.text = "Şimdide listelediğin organların yardımcı yapılarına göre sıralamalısın.";
        }

        if (UI_dragdrop.correct == 11)
        {
            devam.SetActive(true);
        }
    }

    public void ToShow()
    {
        ShowPanel.SetActive(true);
        HidePanel.SetActive(false);
    }

    public void ToHide()
    {
        ShowPanel.SetActive(false);
        HidePanel.SetActive(true);
    }

    public void ToShowHelpMsg()
    {
        HelpPanel.SetActive(true);
        
    }
    public void ToHideHelpMsg()
    {
        HelpPanel.SetActive(false);
    }

    public void last()
    {
        Fade(5);
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        Fade(6);

    }
    public void Text_4()
    {
        txt.text = "Yeni bir görev seni bekliyor. “Tükürük” butonuna tıklamalısın ve karbonhidrat, yağ ve protein içeren besinlerin tükürük ile sindirildikten sonra şekillerindeki değişimleri “Not Defterine Kaydet” butonuna tıklayarak defterine kaydetmelisin. Ardından diğer enzimler için de aynı işlemleri gerçekleştirmelisin.";
    }
}
