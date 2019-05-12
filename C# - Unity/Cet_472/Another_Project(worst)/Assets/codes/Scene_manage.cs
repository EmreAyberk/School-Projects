using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void load1()
    {
        SceneManager.LoadScene(1);
    }

    public void load2()
    {
        SceneManager.LoadScene(2);
    }
    public void load3()
    {
        SceneManager.LoadScene(3);
    }
    public void load4()
    {
        SceneManager.LoadScene(4);
    }
    public void load5()
    {
        SceneManager.LoadScene(5);
    }
    public void load6()
    {
        SceneManager.LoadScene(6);
    }


}
