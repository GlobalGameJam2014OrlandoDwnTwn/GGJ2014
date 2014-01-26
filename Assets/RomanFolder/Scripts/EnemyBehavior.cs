using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	private GameObject player;
	private float maxDistance = 1f;

	NewNodeSystem script;
	
	public float rotationSpeed;
	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		rotationSpeed = 90;
		moveSpeed = 10;
		script = player.GetComponent<NewNodeSystem>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 direction = player.transform.position - transform.position;
		direction.y = 0;
		
		rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x))*Mathf.Rad2Deg - 90);
		
		if ((direction.magnitude <= 20) && (direction.magnitude > maxDistance)) {
			transform.position += moveSpeed * Time.deltaTime * transform.up;
		}
		
		// If really far away, destory enemy. save memory.
		if(direction.magnitude >= 500) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject == player) {
			Destroy(other);
			//script.kill();
		}
	}
}


