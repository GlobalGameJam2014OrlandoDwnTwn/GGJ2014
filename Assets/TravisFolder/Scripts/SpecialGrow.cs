using UnityEngine;
using System.Collections;

public class SpecialGrow : MonoBehaviour {

	public GameObject Atom;

	ArrayList lastLayer = new ArrayList();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			this.GetComponent<SpriteRenderer>().enabled = true;
			StartCoroutine("Blossom");
		}
	}

	IEnumerator Blossom() {

		ArrayList temp;

		temp = AddToArrayList(new int[] {1, 2, 3, 4, 5, 6, 7, 8});
		SpawnLayer(1, temp, true);

		yield return new WaitForSeconds(.5f);

		temp = AddToArrayList(new int[]{2, 3, 4, 6, 7, 8, 10, 11, 12, 14, 15, 16});
		SpawnLayer(2, temp, false);

		yield return new WaitForSeconds(0.5f);
		temp = AddToArrayList(new int[]{4, 10, 16, 22});
		SpawnLayer (3, temp, true);
	}

	ArrayList AddToArrayList(int[] list){
		ArrayList temp = new ArrayList();
		for (int i = 0; i < list.Length; i++) {
			temp.Add (list[i]);
		}
		return temp;
	}

	void SpawnLayer(int layer, ArrayList spots, bool destroyLastLayer) {

		if (destroyLastLayer) {
			foreach(Object o in lastLayer) {
				Destroy(o);
			}
		}
		else {
			lastLayer.Clear();
		}
			

		int counter = 0;

		int i, j;

		// Top left -> top right
		j = layer;
		for (i = -layer; i < layer; i++) {
			counter++;
			if (spots.Contains(counter)) {
				lastLayer.Add(Instantiate (Atom, transform.position + new Vector3(i, j, 1), transform.rotation));
			}
		}
		// Top right -> bottom right
		i = layer;
		for (j = layer; j > -layer; j--) {
			counter++;
			if (spots.Contains(counter)) {
				lastLayer.Add(Instantiate (Atom, transform.position + new Vector3(i, j, 1), transform.rotation));			
			}
		}
		// bottom right -> bottom left
		j = -layer;
		for (i = layer; i > -layer; i--) {
			counter++;
			if (spots.Contains(counter)) {
				lastLayer.Add(Instantiate (Atom, transform.position + new Vector3(i, j, 1), transform.rotation));			
			}
		}
		// bottom left -> top right
		i = -layer;
		for (j = -layer; j < layer; j++) {
			counter++;
			if (spots.Contains(counter)) {
				lastLayer.Add(Instantiate (Atom, transform.position + new Vector3(i, j, 1), transform.rotation));			
			}
		}
	}
}
