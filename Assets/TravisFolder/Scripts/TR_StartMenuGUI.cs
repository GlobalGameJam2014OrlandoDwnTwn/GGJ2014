using UnityEngine;
using System.Collections;

public class TR_StartMenuGUI:MonoBehaviour
{
	//Declare the game background.
	public Texture gameBackground;

	//Declare the start title.
	public Texture startTitle;

	//Declare the play button.
	public Texture playButton;

	void OnGUI()
	{
		//Instantiate the game background.
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameBackground);

		//Instantiate the game title.
		GUI.Label(new Rect (300, 10, startTitle.width, startTitle.height), startTitle);

		//Instantiate the play button.
		if(GUI.Button(new Rect(500, 300, playButton.width, playButton.height), playButton))
		{
			//Check to see if the play button is pressed.
			//Load the main play scene.
			Application.LoadLevel ("TravisScene");
		}


	}
}
