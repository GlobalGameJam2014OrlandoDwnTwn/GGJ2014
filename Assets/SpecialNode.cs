using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {

	public GameObject particle2;

	bool hasFired = false;
	public GameObject Enemy;
	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && !hasFired) {
			StartCoroutine("ParticlePlay");

			SpawnEnemies();

			hasFired = true;

		}
	}
	IEnumerator ParticlePlay() {

		GameObject temp = (GameObject)Instantiate(particle2, transform.position, transform.rotation);
		temp.GetComponent<Animator>().Play("RingShrink");
		temp.transform.parent = this.transform;
		yield return 0;

	}

	void SpawnEnemies() {
		for (int i = 0; i < 2; i++) {
			Instantiate(Enemy, transform.position + new Vector3(-15 + Random.value * 30, -15 + Random.value * 30, 0), transform.rotation);
		}
	}
}
