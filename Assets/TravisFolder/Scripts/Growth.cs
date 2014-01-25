using UnityEngine;
using System.Collections;

public class Growth : MonoBehaviour {

	public bool inRange;
	float timer;

	public GameObject Atom;

	bool [ , ] occupied;


	// Use this for initialization
	void Start () {

		occupied = new bool[11, 11];
		for (int i = 0; i < 11; i++){
			for (int j = 0; j < 10; j++) {
				occupied[i,j] = false;
			}
		}
		occupied[5,5] = true;

		ResetTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (inRange && timer <= 0) {
			ResetTimer();
			Grow();
		}

		if (timer <= 0){
			ResetTimer();
		}
	}

	void ResetTimer() {
		timer = Random.value;
	}

	void Grow() {

		Vector2 loc = new Vector2(5, 5);
		while (occupied[(int)loc.x, (int)loc.y] == true) {
			if (!(loc.x > 10 || loc.x < 0 || loc.y > 10 || loc.y < 0))
				loc = new Vector2 (loc.x + Mathf.Floor(-1 + Random.value * 3), loc.y + Mathf.Floor (-1 + Random.value * 3));
		}
		occupied[(int)loc.x, (int)loc.y] = true;

		Instantiate (Atom, transform.position + new Vector3(-5 + loc.x, -5 + loc.y, 1), transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("IN");
			inRange = true;
		}
	}

	void OnTriggerStay2D(Collider2D other) {

		StopCoroutine("Leave");
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine("Leave");
		}
	}

	IEnumerator Leave() {
		yield return new WaitForSeconds(3);
		inRange = false;
	}
}
