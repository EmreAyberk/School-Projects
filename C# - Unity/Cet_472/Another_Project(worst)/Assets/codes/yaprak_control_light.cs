using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yaprak_control_light : MonoBehaviour
{
    public static int tac;
    public static int canak;
    public static int disi;
    public static int erkek;
    public static int tabla;
    public Text metin;
    public static int metinCounter;
    public GameObject button;

    public GameObject StartButton;

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
            metin.text = "Bitkinin güzel kokulu, renkli yapraklarıdır. Tozlaşmanın gerçekleşmesi için böceklerin bitkiye gelmesini sağlar.";

            if (tac == 3)
            {
                metin.text = "Üreme için gereken polenlerin(spermlerin) oluştuğu yerdir. Uzun bir sapçık ve üzerinde yuvarlak başçıklardan oluşan bir yapıdır.";

                if (erkek == 2)
                {
                    metin.text = "Çiçeğin en dışındaki yeşil renkli yapraklarıdır. Fotosentez ile bitkinin kendi besinini üretmesini sağlar.";

                    if (canak == 2)
                    {
                        metin.text = "Yeşil renklidir, çiçeğin alt kısmında bulunur. Çiçeği taşıyarak bir arada tutar.";
                        if (tabla == 1)
                        {
                            metin.text = "Tebrikler, bu görevi de başarıyla tamamladın. Sıradaki göreve geçebilirsin.";
                            button.SetActive(true);

                        }
                    }
                }
            }

        }
    }

    public void StartTask()
    {
        metin.text = "Çiçeğin tam ortasında bulunur. Uzun bir tüp şeklindedir, içinde bitkinin üremesi için gereken yumurta hücreleri bulunur.";
    }


}
