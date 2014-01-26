﻿using UnityEngine;
using System.Collections;

public class NewNodeSystem : MonoBehaviour {

	public GameObject Node;
	public int maxNodesOnScreen;

	public GameObject[] Nodes;
	
	// Use this for initialization
	void Start () {
		maxNodesOnScreen = 5;
		makeNodes();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void makeNodes() {
		Nodes = new GameObject[5];
		int i = 0;
		while(maxNodesOnScreen >= 1) {
			Nodes[i] = (GameObject) Instantiate(Node, transform.position + 
			                       new Vector3(Random.value * 60, Random.value * 60, 1), transform.rotation);
			maxNodesOnScreen--;
			i++;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		for(int i = 0; i < 5; i++) {
			if (other.gameObject != Nodes[i])
				Destroy(Nodes[i]);
			else
				Nodes[i] = null;
		}

		maxNodesOnScreen = 5;
		makeNodes();
	}
}