using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eseysiz_control : MonoBehaviour
{
    public static bool b1;
    public static bool b2;
    public static bool b3;
    public static bool b4;
    public static bool b5;

    public GameObject buton;

    // Start is called before the first frame update
    void Start()
    {
        b1 = false;
        b2 = false;
        b3 = false;
        b4 = false;
        b5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (b1 && b2 && b3 && b4 && b5)
        {
            buton.SetActive(true);
        }
    }
}
