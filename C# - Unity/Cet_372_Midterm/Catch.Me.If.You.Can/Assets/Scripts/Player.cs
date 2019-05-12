using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float mSpeed=2;
    public static int GameOn;

    
    // Use this for initialization
    void Start () {
        GameOn = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            this.transform.Translate(0, 0, mSpeed*Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {

            this.transform.Translate(0, 0,-1* mSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            this.transform.Translate(-1*mSpeed * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            this.transform.Translate(mSpeed * Time.deltaTime, 0, 0);

        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }

    void GameOver()
    {
        GameOn = 0;

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(8);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(7);
        }

    }
    void GameWin()
    {
        GameOn = 0;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(5);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "enemy" )
        {
            Destroy(this.gameObject, 0.3f);
            Destroy(collision.gameObject, 0.3f);
            GameOver();
        }
        if(collision.gameObject.tag == "point")
        {
            mSpeed++;
            Destroy(collision.gameObject, 0.2f);
        }
        if(collision.gameObject.name=="Finish")
        {
            GameWin();
        }
    }
}
