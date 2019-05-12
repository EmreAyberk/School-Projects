using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Text_Control : Fade_InOut
{

    public Text txt;
    int GameOn = 0;
    public GameObject volun;
    public GameObject glass;
    // Use this for initialization
    public static int glass_count = 1;
    public GameObject glass_button;
    public Texture2D cursor;

	bool isOpended = false;


    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        if (GameOn == 0)
        {
            Text_1();
            
        }
        if (GameOn == 1)
        {
            Text_2();
            Volunteer();
        }
        else if (GameOn == 2)
        {
            Text_3();
            
			if (!isOpended)
			{
				glass_button.SetActive(true);
			}
			else {
				glass_button.SetActive(false);
			}
				
		}







         if(glass_count%2==0 && !isOpended)
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            // glass.SetActive(true);
        }
         else if (glass_count % 2 != 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            // glass.SetActive(false);
        }


    }
    public void Text_1()
    {
        txt.text = "Sindirim Sistemi Kongresine hoş geldin  " + Name.player_name + ". Eğer bu kongrede başarı gösterirsen bu laboratuvarın yeni profesörü sen olacaksın.Görevleri görmek için “Devam Et” butonuna tıklamalısın.";
    }
    public void Text_2()
    {
        txt.text = "İlk görevin sindirim sistemini özel bir büyüteç yardımıyla gözlemeyerek organların yerlerini ve görevlerini keşfetmek olacak. Bunun için önce büyütece tıklayıp ardından fareni insan vücudunun üzerinde gezdirmelisin. Organları not almalısın. İlk görevine başlamak için sedyede yatan gönüllüye tıklamalısın.";
    }
    public void Text_3()
    {
        txt.text = "İlk görevin sindirim sitemindeki organları ve sindirim sitemine yardımcı yapıları keşfetmek. Ekranın sağ üstündeki büyütece tıklamalısın ve ardından tüm sindirim sistemi organ ve yapılarına tıklayıp onları dikkatlice incelemelisin.Bütün organları ve yapıları incelediğinde ekrandaki “Not Defterine Kaydet” butonuna tıklayarak onları defterine kaydetmelisin.";
    }
    
    public void Game_Control()
    {
       
            GameOn++;
        

    }
    public void Game_Control1()
    {
        if (GameOn != 1)
        {
            GameOn++;
        }

    }
    public void Volunteer()
    {
        volun.SetActive(true);
    }
    public void Glasses()
    {
        glass_count++;
    }
	public void ChangeGlass()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		isOpended = true;
	}
    public void NotOpen()
    {
        isOpended = false;
    }
    public void conti()
    {
        
        if (Glass.cont && GameOn>2)
        {
            Glass.note.SetActive(false);
            Fade(3);
        }
    }
}
