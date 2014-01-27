using UnityEngine;
using System.Collections;

public class PatricksGrowth : MonoBehaviour {

	public bool inRange;
	float timer;
	public float deathTimer;
	
	public GameObject Atom;
	public Sprite DecaySprite;

	public bool found;
	public GameObject player;
	private ScoreScript scoreScript;
	// end
	
	public struct Node {
		public bool occupied;
		public bool decaying;
		public GameObject instantiatedNode;
		public bool isSurrounded;
		public Vector2 loc;
	}
	
	Node[,] nodeArray;
	void Awake()
	{
		player = GameObject.FindWithTag("Player");
		scoreScript = player.GetComponent<ScoreScript>();
	}
	
	// Use this for initialization
	void Start () {
		// Jills shit
		found = false;
		// end
		
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
		deathTimer -= Time.deltaTime/2;
		
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
				
				if (nodeCounter >= 3) {
					nodeArray[(int)loc.x, (int)loc.y].isSurrounded = true;
					break;
				}
			}
		}
		
		nodeArray[(int)loc.x, (int)loc.y].occupied = true;
		nodeArray[(int)loc.x, (int)loc.y].loc = loc;
		
		Debug.Log (loc.x);
		Debug.Log (loc.y);
		
		nodeArray[(int)loc.x, (int)loc.y].instantiatedNode = (GameObject)
			Instantiate (Atom, transform.position + new Vector3(-5 + loc.x, -5 + loc.y, 1), transform.rotation);
		
		if (!nodeArray[(int)loc.x, (int)loc.y].isSurrounded) {
			nodeArray[(int)loc.x, (int)loc.y].decaying = true;
			StartCoroutine("Decay", nodeArray[(int)loc.x, (int)loc.y]);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Debug.Log ("IN");
			inRange = true;
			
			if(!found)
			{
				found = true;
				scoreScript.StartScore();
			}
			// end
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
	
	IEnumerator Decay(Node d) {
		int nodeCounter = 0;
		yield return new WaitForSeconds(4);
		for(int i = -1; i < 1; i++) {
			for(int j = -1; j < 1; j++) {
				if((i == 0) && (j == 0))
					continue;
				
				// checks the 8 blocks around the live node in question.
				if(nodeArray[(int)d.loc.x + i, (int)d.loc.y + j].occupied == true)
					nodeCounter++;
				
				if (nodeCounter >= 3) {
					d.isSurrounded = true;
					break;
				}
			}
		}
		if (!d.isSurrounded)
			d.instantiatedNode.GetComponent<SpriteRenderer>().sprite = DecaySprite;
		
	}
}
