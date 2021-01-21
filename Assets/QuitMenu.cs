using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour {

	public void ExitGame()
	{
		print("Exiting...");
		Application.Quit();
	}
}
