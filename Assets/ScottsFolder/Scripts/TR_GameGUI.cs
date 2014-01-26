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

	private GameObject player;

	private ScoreScript scoreScript;

	//Declare the score value.
	private float gameScoreValue;
	private int gameMultiValue;

	//Declare

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		scoreScript = player.GetComponent<ScoreScript>();
	}

	void OnGUI()
	{
		gameScoreValue = (int)scoreScript.GetScore();
		gameMultiValue = scoreScript.multiplier;
		string scoreText = "" + gameScoreValue;
		string multiText = "" + gameMultiValue;

		//Instantiate score object.
		GUI.Label(new Rect(200, 10, 50, 50), scoreText);
		GUI.Label(new Rect(10, 10, gameScore.width / 4, gameScore.height / 4), gameScore);


		//Instantiate the Multiplier value.
		GUI.Label (new Rect(600, 15, 100, 100), multiText);
		//Instantiate combo object.
		GUI.Label(new Rect(400, 15, gameCombo.width / 5, gameCombo.height / 5), gameCombo);

		//Instantiate the multiplier object.
		GUI.Label (new Rect(550, 15, gameMulti.width / 5, gameMulti.height / 5), gameMulti);
	}
}
