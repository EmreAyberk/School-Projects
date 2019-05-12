using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public static bool ilktopmu = false;
	public static int zemintopsayisi=0;
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "block") {
			int can = col.gameObject.GetComponent<blockScript> ().life;
			if (can == 1) {
				Destroy (col.gameObject);
			} else {
				can = can - 1;
				col.gameObject.GetComponent<blockScript> ().canata (can);
			}
		}
		if (col.gameObject.name == "zemin") {
			zemintopsayisi++;

			if (zemintopsayisi == shoot_Script.atissayisi) {
				GameObject.Find ("shoot").GetComponent<shoot_Script> ().atisyapilabilir = true;
				zemintopsayisi = 0;
				shoot_Script.atissayisi += bonus;
				bonus = 0;
			}

			if (!ilktopmu) {
				ilktopmu = true;
				this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GameObject.Find ("shoot").GetComponent<shoot_Script> ().ball = this.gameObject;

			} else {
				Destroy (this.gameObject);
			}
		}
	}
	public static int bonus = 0;
	void OnTriggerEnter(Collider col)
	{
		//shoot_Script.atissayisi++;
		bonus++;
		Debug.Log ("Objeye çarptık");
		Destroy (col.gameObject);
	}
}
