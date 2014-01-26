using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {

	public ParticleSystem particle;
	// Use this for initialization
	void Awake () {
		particle = this.GetComponent<ParticleSystem>();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			particle.Play();
		}
	}
}
