using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerMenu : MonoBehaviour
{

	public Text title;
	int buttonClick = 0;

	// Use this for initialization
	void Start()
	{
		//title.text = "Game Of Life";
	}

	public void ButtonPress(string SampleScene)
	{
		buttonClick++;
		//title.text = "Button Was pressed: " + buttonClick;

		if (buttonClick >= 1)
		{
			SceneManager.LoadScene(SampleScene);
		}
	}
}
