using UnityEngine;
using System.Collections;

public class TR_GameGUI:MonoBehaviour
{
	//Declare score object.
	public Texture gameScore;

	void OnGUI()
	{
		//Instantiate score object.
		GUI.Label(new Rect(10, 10, gameScore.width / 4, gameScore.height / 4), gameScore);
	}
}
