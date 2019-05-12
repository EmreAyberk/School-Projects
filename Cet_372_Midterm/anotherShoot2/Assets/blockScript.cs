using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockScript : MonoBehaviour {

	public int life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Sprite[] renkler;
	public void canata(int can)
	{
		life = can;
		this.GetComponent<SpriteRenderer>().sprite=renkler[can];
	}
}
