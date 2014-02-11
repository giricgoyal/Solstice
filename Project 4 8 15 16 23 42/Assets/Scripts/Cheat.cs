using UnityEngine;
using System.Collections;

public class Cheat : MonoBehaviour
{
	public Transform teleport1;
	public Transform teleport2;
	public Transform teleport3;
	public Transform teleport4;
	public Transform teleport5;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if(Input.GetKeyDown(KeyCode.C))
		{
			Utilities.saludBar=100;
			Utilities.magiaBarFall=100;
			Utilities.magiaBarSpring=100;
			Utilities.magiaBarSummer=100;
			Utilities.magiaBarWinter=100;
		}
		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			transform.position=teleport1.position;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha6))
		{
			transform.position=teleport2.position;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			transform.position=teleport3.position;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			transform.position=teleport4.position;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha9))
		{
			transform.position=teleport5.position;
		}
	}
}