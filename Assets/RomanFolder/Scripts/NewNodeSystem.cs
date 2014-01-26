using UnityEngine;
using System.Collections;

public class NewNodeSystem : MonoBehaviour {

	public GameObject Node;
	public int maxNodesOnScreen;

	public GameObject[] Nodes;

	public float radius = 40;

	float c1;
	float c2;
	float s1;
	float s2;
	
	// Use this for initialization
	void Start () {

		c1 = Mathf.Cos (2 * Mathf.PI / 5);
		c2 = Mathf.Cos (Mathf.PI / 5);
		s1 = Mathf.Sin (2 * Mathf.PI / 5);
		s2 = Mathf.Sin (4 * Mathf.PI / 5);


		maxNodesOnScreen = 5;
		makeNodes();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void makeNodes() {
		Nodes = new GameObject[5];
		int i = 0;
		int counter = 0;
		while(maxNodesOnScreen >= 1) {
			counter++;
			switch(counter){
			case 1:
				Nodes[i] = (GameObject) Instantiate(Node, transform.position + new Vector3(radius * -s1 - 10 + Random.value * 20,
				                                                                           radius * c1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation);
				break;
			case 2:
				Nodes[i] = (GameObject) Instantiate(Node, transform.position + new Vector3(radius * 0 - 10 + Random.value * 20,
				                                                                           radius * 1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation);				
				break;
			case 3:
				Nodes[i] = (GameObject) Instantiate(Node, transform.position + new Vector3(radius * s1 - 10 + Random.value * 20,
				                                                                           radius * c1 - 10 + Random.value * 20,
				                                                                           1), transform.rotation);				
				break;
			case 4:
				Nodes[i] = (GameObject) Instantiate(Node, transform.position + new Vector3(radius * s2 - 10 + Random.value * 20,
				                                                                           radius * -c2 - 10 + Random.value * 20,
				                                                                           1), transform.rotation);				
				break;
			case 5:
				Nodes[i] = (GameObject) Instantiate(Node, transform.position + new Vector3(radius * -s2 - 10 + Random.value * 20,
				                                                                           radius * -c2 - 10 + Random.value * 200,
				                                                                           1), transform.rotation);				
				break;
			}

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
