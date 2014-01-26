using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {

	ParticleSystem particle;
	public GameObject particle2;
	public GameObject Enemy;
	// Use this for initialization
	void Awake () {
		particle = this.GetComponent<ParticleSystem>();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine("ParticlePlay");
			SpawnEnemies();

		}
	}
	IEnumerator ParticlePlay() {

		particle.Play();

		yield return new WaitForSeconds(1);
		if (transform.childCount > 0)
			Destroy(transform.FindChild("wind").gameObject);
		Instantiate(particle2, transform.position, transform.rotation);

	}

	void SpawnEnemies() {
		for (int i = 0; i < 10; i++) {
			Instantiate(Enemy, transform.position + new Vector3(-15 + Random.value * 30, -15 + Random.value * 30, 0), transform.rotation);
		}
	}
}
