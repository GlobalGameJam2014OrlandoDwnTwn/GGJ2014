using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	int lives;

	// Use this for initialization
	void Start () {
		lives = 3;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Escape))
			Application.Quit();
	
	}

	public void PlayerDeath() {
		Debug.Log ("E");
		lives--;
		StartCoroutine("Restart");
	}

	IEnumerator Restart() {

		GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject o in e) {

			Destroy(o.gameObject);
		}
		Camera.main.GetComponent<PlayerFollow>().target = Camera.main.transform;

		yield return new WaitForSeconds(2);
		Application.LoadLevel("TravisScene");

	}


	
}
