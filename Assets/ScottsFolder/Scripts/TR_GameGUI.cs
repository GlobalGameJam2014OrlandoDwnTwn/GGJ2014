using UnityEngine;
using System.Collections;

public class TR_GameGUI:MonoBehaviour
{
	//Declare score object.
	public Texture gameScore;

	//Declare the combo object.
	public Texture gameCombo;

	//Declare the multiplier object.
	public Texture gameMulti;

	void OnGUI()
	{
		//Instantiate score object.
		GUI.Label(new Rect(10, 10, gameScore.width / 4, gameScore.height / 4), gameScore);

		//Instantiate combo object.
		GUI.Label(new Rect(400, 15, gameCombo.width / 5, gameCombo.height / 5), gameCombo);

		//Instantiate the multiplier object.
		GUI.Label (new Rect(550, 15, gameMulti.width / 5, gameMulti.height / 5), gameMulti);
	}
}
