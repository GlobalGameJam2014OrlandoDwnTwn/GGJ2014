﻿using UnityEngine;
using System.Collections;

public class RomansGrowth : MonoBehaviour {
	
	public bool inRange;
	float timer;

	public GameObject Atom;
	
	public struct Node {
		public bool occupied;
		public bool decaying;
		public GameObject instantiatedNode;
		public float decayTimer;
	}
	
	Node[,] nodeArray;
	
	// Use this for initialization
	void Start () {

		nodeArray = new Node[10, 10];
		for (int i = 0; i < 10; i++){
			for (int j = 0; j < 10; j++) {
				nodeArray[i,j].occupied = false;
			}
		}
		nodeArray[4,4].occupied = true;		// the life node starts occupied.
		nodeArray [4, 4].decaying = false; 	// the life node doesn't decay.
		
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

		int nodeCounter = 0;
		bool isSurrounded = false;
		
		Vector2 loc = new Vector2(4, 4);
		while (nodeArray[(int)loc.x, (int)loc.y].occupied == true) {
			loc = new Vector2 (loc.x + Mathf.Floor(-1 + Random.value * 3), loc.y + Mathf.Floor (-1 + Random.value * 3));
		}

		for(int i = -1; i < 1; i++) {
			for(int j = -1; j < 1; j++) {
				if((i == 0) && (j == 0))
					continue;
				
				// checks the 8 blocks around the live node in question.
				if(nodeArray[(int)loc.x + i, (int)loc.y + j].occupied == true)
					nodeCounter++;
				
				if (nodeCounter == 5) {
					isSurrounded = true;
					break;
				}
			}
		}

		nodeArray[(int)loc.x, (int)loc.y].occupied = true;
		
		Debug.Log (loc.x);
		Debug.Log (loc.y);

		nodeArray[(int)loc.x, (int)loc.y].instantiatedNode = (GameObject)
			Instantiate (Atom, transform.position + new Vector3(-5 + loc.x, -5 + loc.y, 1), transform.rotation);

		if (!isSurrounded) {
			nodeArray[(int)loc.x, (int)loc.y].decaying = true;
			nodeArray[(int)loc.x, (int)loc.y].decayTimer = 4f;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("IN");
			inRange = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D other) {
		
		StopCoroutine("Leave");
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