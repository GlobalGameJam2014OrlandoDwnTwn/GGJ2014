using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewNodeSystem : MonoBehaviour {

	public GameObject Node;
	public int maxNodesOnScreen;


	public float radius = 40;

	public int level;

	float c1;
	float c2;
	float s1;
	float s2;

	ArrayList Nodes = new ArrayList();
	
	// Use this for initialization
	void Start () {
		level = 2;

		c1 = Mathf.Cos (2 * Mathf.PI / 5);
		c2 = Mathf.Cos (Mathf.PI / 5);
		s1 = Mathf.Sin (2 * Mathf.PI / 5);
		s2 = Mathf.Sin (4 * Mathf.PI / 5);


		maxNodesOnScreen = 5;
		makeNodes();
		StartCoroutine("CheckDistance");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void makeNodes() {
		Nodes.Clear();
		int i = 0;
		int counter = 0;
		while(maxNodesOnScreen >= 1) {
			counter++;
			switch(counter){
			case 1:
				Nodes.Add((GameObject) Instantiate(Node, transform.position + new Vector3(radius * -s1 - 10 + Random.value * 20,
				                                                                           radius * c1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation));
				break;
			case 2:
				Nodes.Add ((GameObject) Instantiate(Node, transform.position + new Vector3(radius * 0 - 10 + Random.value * 20,
				                                                                           radius * 1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation));				
				break;
			case 3:
				Nodes.Add((GameObject) Instantiate(Node, transform.position + new Vector3(radius * s1 - 10 + Random.value * 20,
				                                                                           radius * c1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation));				
				break;
			case 4:
				Nodes.Add((GameObject) Instantiate(Node, transform.position + new Vector3(radius * s2 - 10 + Random.value * 20,
				                                                                           radius * -c2 - 10 + Random.value * 20,
				                                                                           1), transform.rotation));				
				break;
			case 5:
				Nodes.Add ((GameObject) Instantiate(Node, transform.position + new Vector3(radius * -s2 - 10 + Random.value * 20,
				                                                                           radius * -c2 - 10 + Random.value * 200,
				                                                                           1), transform.rotation));				
				break;
			}

			maxNodesOnScreen--;
			i++;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		level++;

		for(int i = 0; i < Nodes.Count; i++) {
			if (other.gameObject != Nodes[i])
				Destroy((GameObject)Nodes[i]);
			else
				Nodes.RemoveAt(i);
		}

		maxNodesOnScreen = 5;
		makeNodes();
	}

	IEnumerator CheckDistance() {

		yield return new WaitForSeconds(4);
		for (int i = 0; i < Nodes.Count; i++ ){ 
			if (Vector3.Distance(((GameObject)(Nodes[i])).transform.position, transform.position) >= 200) {
				Debug.Log ("Reset");
				for (int j = 0 ; j < Nodes.Count; j++) {
					Destroy ((GameObject)Nodes[i]);
				}
				makeNodes();
			}
		}

		StartCoroutine("CheckDistance");
	}
}
