using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade_InOut : MonoBehaviour {

    public Image Black;
    public Animator Anim;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fade(int x)
    {
        StartCoroutine(Fading(x));
    }

    IEnumerator Fading(int x)
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        SceneManager.LoadScene(x);
    }
}
