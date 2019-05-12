using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//CANVAS İÇİN GEREKLİ

public class shoot_Script : MonoBehaviour {

	//int hamle=5;
	//public Text hamletxt;

	// Use this for initialization
	public GameObject block;
	public Sprite[] numbers;
	void Start () 
	{
		//hamletxt.GetComponent<Text> ().text = hamle.ToString ();
		for (int i = 0; i < 3; i++) 
		{
			for (int j = 0; j < 3; j++) {

				int k = Random.Range (1, 6);
				GameObject newblock=Instantiate (block, new Vector3 (-3, 6, 0)+new Vector3(i*3,j*-3,0), Quaternion.identity);
				newblock.GetComponent<blockScript> ().life = k;
				newblock.GetComponent<SpriteRenderer> ().sprite = numbers [k];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	Vector3 mousepos;
	Vector3 ballpos;
	Vector3 kuvvet;

	public GameObject ball; 


	void OnMouseUp()
	{

		//Debug.Log (ball.GetComponent<Rigidbody> ().velocity);
		//if (hamle > 0&& Mathf.Abs(ball.GetComponent<Rigidbody>().velocity.x)<0.8f&&Mathf.Abs(ball.GetComponent<Rigidbody>().velocity.z)<0.8f) {

			//ball_script.kirmizicarpma = false;
			//ball_script.saricarpma = false;
			//ball_script.sayialindimi = false;

			//hamle--;
			//hamletxt.GetComponent<Text> ().text = hamle.ToString ();

			ballpos = ball.GetComponent<Transform> ().position;
			ballpos = Camera.main.WorldToViewportPoint (ballpos);


			//ballpos = GameObject.Find ("whiteball").GetComponent<Transform> ().position;
			mousepos = Input.mousePosition;
			mousepos = Camera.main.ScreenToViewportPoint (mousepos);

			Debug.Log (mousepos);
			Debug.Log (ballpos);
			kuvvet = new Vector3 ((mousepos.x - ballpos.x)*1000, (mousepos.y - ballpos.y)*1000,0 );
			Debug.Log ("Kuvvet" + kuvvet.magnitude);
			//if (kuvvet.magnitude < 10) {
			//	kuvvet = new Vector3 (kuvvet.x*1000, 0, kuvvet.y*1000);
			//}

			
		//} else {
		//	Debug.Log ("Oyun Bitti");
		//}
		if (atisyapilabilir) {
			StartCoroutine (atisyap ());
			atisyapilabilir = false;
		}

	}
	Vector3 topilkkonum;
	public bool atisyapilabilir=true;
	public static int topsayisi=3;
	//public static int temptopsayisi;


	IEnumerator atisyap()
	{
		ballScript.ilktopbulundu = false;
		ballScript.dusentopsayisi = 0;

		topilkkonum = ball.GetComponent<Transform> ().position;
		//ball.transform.position = new Vector3 (-10, 0, 0);
		ball.GetComponent<SphereCollider>().enabled=false;

		for (int i = 0; i < topsayisi; i++) {
			yield return new WaitForSeconds (0.5f);
			GameObject yenitop = Instantiate (ball, topilkkonum, Quaternion.identity);
			yenitop.GetComponent<Rigidbody> ().AddForce (kuvvet);
			yenitop.GetComponent<SphereCollider> ().enabled = true;
		}
		ball.SetActive (false);


	}
}
