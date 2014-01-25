using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Atom;
	public GameObject Node;

	int xSize = 80;
	int ySize = 45;


	// Use this for initialization
	void Start () {

		for (int i = 0; i < 5; i++) {
			Instantiate(Node, transform.position + new Vector3(Random.value * xSize, Random.value * ySize, 1), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
