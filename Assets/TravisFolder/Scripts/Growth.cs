using UnityEngine;
using System.Collections;

public class Growth : MonoBehaviour {

	public bool inRange;
	float timer;

	public GameObject Atom;

	// Use this for initialization
	void Start () {
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
		Instantiate (Atom, transform.position + new Vector3((int)(-5 + Random.value * 10), (int)(-5 + Random.value * 10), 1), transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("IN");
			inRange = true;
		}
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
