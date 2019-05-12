using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Sprite[] sayilar;
	public static bool ilktopbulundu=false;
	public static int dusentopsayisi=0;
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "block") {
			int k = col.gameObject.GetComponent<blockScript> ().life;
			if (k == 1)
				Destroy (col.gameObject);
			else
			{
				k--;
				col.gameObject.GetComponent<blockScript> ().life = k;
				col.gameObject.GetComponent<SpriteRenderer> ().sprite = sayilar [k];

			}
		}
		if (col.gameObject.name == "zemin") {

			dusentopsayisi++;

			if (!ilktopbulundu) {
				ilktopbulundu = true;
				GameObject.Find ("tiklamaalani").GetComponent<shoot_Script> ().ball = this.gameObject;


			} else {
				Destroy (this.gameObject);
			}

			this.GetComponent<Rigidbody> ().velocity = Vector3.zero;

			if (dusentopsayisi == shoot_Script.topsayisi) {
				GameObject.Find ("tiklamaalani").GetComponent<shoot_Script> ().atisyapilabilir = true;
				shoot_Script.topsayisi += yenialinantop;
				yenialinantop = 0;
			}
			
		}
	}
	public static int yenialinantop=0;
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "yenitop") {
			//shoot_Script.topsayisi++;
			yenialinantop++;
			Debug.Log ("Topa çarptık");
			Destroy (col.gameObject);
		}
	}
}
