using UnityEngine;
using System.Collections;

public class ParticleTest : MonoBehaviour 
{
	private bool keyDown;
	public GameObject myZObject,
				      myCObject,
					  myXObject;
	private GameObject myObject;
		
	private string key;
	
	// Use this for initialization
	void Start () 
	{	
	}

	void Update()
	{
		if (Input.GetKeyDown("z")) /// wanted to turn this into a case to detect different keys, lik z,x,c,v etc
		{
			key = "z";
			myObject = myZObject;
		}

		if (Input.GetKeyDown("x")) /// wanted to turn this into a case to detect different keys, lik z,x,c,v etc
		{
			key = "x";
			myObject = myXObject;
		}

		if (Input.GetKeyDown("c")) /// wanted to turn this into a case to detect different keys, lik z,x,c,v etc
		{
			key = "c";
			myObject = myCObject;
		}

		Test ();
	}
	
	void Test()
	{

		if (Input.GetKey(key) && Input.GetKeyDown ("space"))  // trying use the key variable in the input.getkey is not working
		{
			Instantiate(myObject, transform.position + new Vector3( 40, 25, 0), transform.rotation);	
			print ("space");
		}
	}
}



