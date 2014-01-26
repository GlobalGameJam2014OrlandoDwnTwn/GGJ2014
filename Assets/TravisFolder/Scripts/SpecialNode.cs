using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {

	public GameObject particle2;

	public GameObject OutWind;

	private ScoreScript scorescript;
	public GameObject player;

	public int numParticleEffects;

	bool found;

	bool hasFired = false;
	public GameObject Enemy;
	// Use this for initialization
	void Awake () {
		scorescript = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreScript>();
		found = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && !hasFired) {
			StartCoroutine("ParticlePlay");

			SpawnEnemies();

			hasFired = true;
			if (!found) {
				scorescript.StartScore ();
				found = true;
			}

		}
	}
	IEnumerator ParticlePlay() {

		int choice = (int)Mathf.Floor (Random.value * numParticleEffects);
	//	GameObject temp = particle2.transform.FindChild(choice.ToString).gameObject;
	//	Instantiate(temp, transform.position, transform.rotation);
	//	temp.transform.parent = this.transform;
		Destroy(this.transform.FindChild("wind").gameObject);

		GameObject temp2 = (GameObject)Instantiate(OutWind, transform.position, transform.rotation);
		temp2.transform.parent = this.transform;

		yield return new WaitForSeconds(1);

		Destroy (this.transform.FindChild("outWind(Clone)").gameObject);

		yield return new WaitForSeconds(5);

		Destroy (this.gameObject);

	}

	void SpawnEnemies() {
		Instantiate(Enemy, transform.position + new Vector3(-15 + Random.value * 30, -15 + Random.value * 30, 0), transform.rotation);
	}
}
