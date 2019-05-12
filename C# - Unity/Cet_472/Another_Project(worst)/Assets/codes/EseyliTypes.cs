using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EseyliTypes : MonoBehaviour
{

    public bool IcDollenme;
    public bool DogurarakCogalma;
    public bool YavruBakim;
    public bool AkcigerSolunum;

    // Start is called before the first frame update
    void Start()
    {
        ////    TYPESSS    ///////
        if (this.tag == "memelisepeti")
        {
            IcDollenme = true;
            DogurarakCogalma = true;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        if (this.tag == "kussepeti")
        {
            IcDollenme = true;
            DogurarakCogalma = false;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        if (this.tag == "kurbagasepeti")
        {
            IcDollenme = false;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = true;
        }
        if (this.tag == "surungensepeti")
        {
            IcDollenme = true;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = true;
        }
        if (this.tag == "baliksepeti")
        {
            IcDollenme = false;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = false;
        }

        /////   LİVİNGS   //////////
        //1-memeli
        if (this.name == "balina")
        {
            IcDollenme = true;
            DogurarakCogalma = true;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        //2-memeli
        if (this.name == "kedi")
        {
            IcDollenme = true;
            DogurarakCogalma = true;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        //3-memeli
        if (this.name == "yarasa")
        {
            IcDollenme = true;
            DogurarakCogalma = true;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        //4-memeli
        if (this.name == "fare")
        {
            IcDollenme = true;
            DogurarakCogalma = true;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        //5-sürüngen
        if (this.name == "timsah")
        {
            IcDollenme = true;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = true;
        }
        //6-kuş
        if (this.name == "papagan")
        {
            IcDollenme = true;
            DogurarakCogalma = false;
            YavruBakim = true;
            AkcigerSolunum = true;
        }
        //7-balık
        if (this.name == "balık")
        {
            IcDollenme = false;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = false;
        }
        //8-burbağa
        if (this.name == "kurbaga")
        {
            IcDollenme = false;
            DogurarakCogalma = false;
            YavruBakim = false;
            AkcigerSolunum = true;
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
