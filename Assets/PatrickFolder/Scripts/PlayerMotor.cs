using UnityEngine;
using System.Collections;

public class PlayerMotor: MonoBehaviour {
	private float currentYAngle = 0;
	public float speed = 3.0f;
	public float rotateSpeed = 90.0f;
	


	
	void Update () 
	{
		float move = -speed * Input.GetAxis("Vertical") * Time.deltaTime;
		
		currentYAngle += rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;

		this.transform.Translate(Vector3.up * move);

		this.transform.eulerAngles = new Vector3(90,currentYAngle, 0);
		
	}
	
}