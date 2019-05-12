using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Name : MonoBehaviour {


    public static string player_name;



    public void NameEnter(Text name)
    {
        player_name = name.text;

        PlayerPrefs.SetString("name", name.text);

        Debug.Log(name.text);
    }
	
    public void EnterButton()
    {
        Input.GetKey(KeyCode.KeypadEnter);
    }


}
