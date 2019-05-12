using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public SceneFader fader;

	public Button[] levelButtons;

	void Start ()
	{
		
	}

	public void Select (string levelName)
	{
		fader.FadeTo(levelName);
	}

}
