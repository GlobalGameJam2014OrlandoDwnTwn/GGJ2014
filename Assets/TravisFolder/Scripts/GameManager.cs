using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Atom;
	public GameObject Node;

	int xSize = 80;
	int ySize = 45;

	GameObject[ , ] grid;

	// Use this for initialization
	void Start () {

		grid = new GameObject[ xSize, ySize];

		for (int i = 0; i < 5; i++) {
			Instantiate(Node, transform.position + new Vector3(Random.value * xSize, Random.value * ySize, 1), transform.rotation);
		}

//		for (int i = 0; i < xSize; i++) {
//			for (int j = 0; j < ySize; j++) {
//				grid[i, j] = (GameObject)Instantiate(Atom, this.transform.position + new Vector3(i * Atom.transform.localScale.x, j * Atom.transform.localScale.y, 1), transform.rotation);
//			}
//		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
