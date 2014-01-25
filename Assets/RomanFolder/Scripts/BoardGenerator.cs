using UnityEngine;
using System.Collections;

public class BoardGenerator : MonoBehaviour {
	
	public GameObject cell;
	public int x;
	public int y;

	// Use this for initialization
	void Start () {
		
		// 2D array that stores gameboard.
		GameObject[,] matrix = new GameObject[x, y];
		
		// Position's board to go from {5, -5} , {4, -4} in 10x10 matrix
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				matrix[i,j] = (GameObject) Instantiate(cell, new Vector2(j-(y/2), i-(x/2)), transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
