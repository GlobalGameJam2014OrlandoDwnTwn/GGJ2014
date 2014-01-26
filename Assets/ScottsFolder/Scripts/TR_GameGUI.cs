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
		gameScoreValue = scoreScript.GetScore();
		gameMultiValue = scoreScript.multiplier;
		string scoreText = "" + gameScoreValue;

		//Instantiate score object.
		GUI.Box(new Rect(150, 0, 50, 50), scoreText);
		GUI.Label(new Rect(10, 10, gameScore.width / 4, gameScore.height / 4), gameScore);

		//Instantiate combo object.
		GUI.Label(new Rect(400, 15, gameCombo.width / 5, gameCombo.height / 5), gameCombo);

		//Instantiate the multiplier object.
		GUI.Label (new Rect(550, 15, gameMulti.width / 5, gameMulti.height / 5), gameMulti);
	}
}
