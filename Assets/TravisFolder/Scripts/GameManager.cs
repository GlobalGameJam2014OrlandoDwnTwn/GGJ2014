using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Node;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 5; i++) {
			Instantiate(Node, transform.position + new Vector3(Random.value * 50, Random.value * 50, 1), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
