using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yaprak_control : MonoBehaviour
{
    public static int tac;
    public static int canak;
    public static int disi;
    public static int erkek;
    public static int tabla;
    public Text metin;
    public static int metinCounter;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        tac = 0;
        canak = 0;
        disi = 0;
        erkek = 0;
        tabla = 0;
        metinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (disi == 1)
        {
            metin.text = "Çiçeğin erkek organıdır, içerisinde polenler bulunur.";
            
            if (erkek == 2)
            {
                metin.text = "Çiçeğe renk ve koku veren yapraklardır.";
                
                if (tac == 3)
                {
                    metin.text = "Çiçeğin en dıştaki yeşil yapraklarıdır.";
                    
                    if (canak == 2)
                    {
                        metin.text= "Çiçeği bir arada tutan yapıdır.";
                        if (tabla == 1)
                        {
                            metin.text = "Bu zor görevi de tamamladın, ileride çok başarılı bir bilim insanı olacağına eminim.";
                            button.SetActive(true);

                        }
                    }
                }
            }
            
        }   
    }
    public void StartTask()
    {
        metin.text = "Çiçeğin dişi organıdır, içerisinde yumurta hücreleri bulunur.";
    }
    


}
