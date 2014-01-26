using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3F;
	private Vector2 velocity = new Vector2(0.5f, 0.5f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		float xNewPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTime);
		float yNewPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTime);
		transform.position = new Vector3(xNewPosition, yNewPosition, transform.position.z);

	}
}
