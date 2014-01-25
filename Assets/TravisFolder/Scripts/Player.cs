using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float rotationSpeed = 200; // how fast the player rotates
	public float vAcceleration = 5; // how fast the player moves (not true acceleration, more like velocity)
	
	void Start () {
	}
	
	void Update () {
		// Controls: WASD or Arrow Keys
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
			Accelerate(vAcceleration);
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
			Accelerate(-vAcceleration);
		
	}
	
	void Accelerate (float a) {
		float tTheta = transform.rotation.eulerAngles.z + 90; // offset for local space
		transform.position += new Vector3(Mathf.Cos (tTheta * Mathf.Deg2Rad), Mathf.Sin (tTheta * Mathf.Deg2Rad), 0) * a * Time.deltaTime;
	}
}
