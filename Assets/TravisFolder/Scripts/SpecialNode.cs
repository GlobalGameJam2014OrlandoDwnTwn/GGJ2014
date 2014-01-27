using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {
	
	public GameObject particle2;
	
	public GameObject OutWind;
	
	private ScoreScript scorescript;
	GameObject player;
	
	public GameObject ParticleEffect1;
	public GameObject ParticleEffect2;
	public int numParticleEffects;
	
	public float numSpawned;
	public float enemyRadius;
	
	bool found;
	
	bool hasFired = false;
	
	float c1;
	float c2;
	float s1;
	float s2;
	
	public GameObject Enemy;
	// Use this for initialization
	void Awake () {
		
		numSpawned = 2;
		scorescript = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreScript>();
		found = false;
		player = GameObject.FindGameObjectWithTag("Player");
		
		c1 = Mathf.Cos (2 * Mathf.PI / 5);
		c2 = Mathf.Cos (Mathf.PI / 5);
		s1 = Mathf.Sin (2 * Mathf.PI / 5);
		s2 = Mathf.Sin (4 * Mathf.PI / 5);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && !hasFired) {
			StartCoroutine("ParticlePlay");
			
			SpawnEnemies();
			DestroyNearbyEnemies();
			
			hasFired = true;
			if (!found) {
				scorescript.StartScore ();
				found = true;
			}
			
		}
	}

	void DestroyNearbyEnemies() {

		StartCoroutine("DeathAnimation");

	}
	IEnumerator ParticlePlay() {
		
		int choice = (int)Mathf.Floor (Random.value * numParticleEffects);
		GameObject temp;
		switch (choice) {
		case 0: 
			temp = (GameObject)Instantiate(ParticleEffect1, transform.position, transform.rotation);
			break;
			
		case 1: 
			temp = (GameObject)Instantiate(ParticleEffect2, transform.position, transform.rotation);
			break;
			
		default:
			temp = (GameObject)Instantiate(ParticleEffect1, transform.position, transform.rotation);
			break;
		}
		temp.transform.parent = this.transform;
		Destroy(this.transform.FindChild("wind").gameObject);
		
		GameObject temp2 = (GameObject)Instantiate(OutWind, transform.position, transform.rotation);
		temp2.transform.parent = this.transform;
		
		yield return new WaitForSeconds(1);
		
		Destroy (this.transform.FindChild("outWind(Clone)").gameObject);
		
		yield return new WaitForSeconds(5);
		
		Destroy (this.gameObject);
		
	}
	
	void SpawnEnemies() {
		
		numSpawned = player.GetComponent<NewNodeSystem>().level;
		
		for (int i = 0; i < numSpawned; i++) {
			float tempRadius = enemyRadius;
			if (Mathf.Floor (i / 5) > 0)
				tempRadius = enemyRadius * Mathf.Floor (i / 5);
			switch(i % 5){
			case 0:
				Instantiate(Enemy, transform.position + new Vector3(tempRadius * -s1,
				                                                    tempRadius * c1,
				                                                    1), transform.rotation);
				break;
			case 1:
				Instantiate(Enemy, transform.position + new Vector3(tempRadius * 0,
				                                                    tempRadius * 1,
				                                                    1), transform.rotation);                                
				break;
			case 2:
				Instantiate(Enemy, transform.position + new Vector3(tempRadius * s1,
				                                                    tempRadius * c1,
				                                                    1), transform.rotation);                                
				break;
			case 3:
				Instantiate(Enemy, transform.position + new Vector3(tempRadius * s2,
				                                                    tempRadius * -c2,
				                                                    1), transform.rotation);                                
				break;
			case 4:
				Instantiate(Enemy, transform.position + new Vector3(tempRadius * -s2,
				                                                    tempRadius * -c2,
				                                                    1), transform.rotation);                                
				break;
			}
		}
	}

	IEnumerator DeathAnimation() {

		yield return new WaitForSeconds(0.5f);

		Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position, 20);
		foreach (Collider2D c in cols) {
			if (c.gameObject.tag == "Enemy"){
				scorescript.AddScore(50);
				c.gameObject.GetComponent<EnemyBehavior>().Kill();
			}
		}
	}
}