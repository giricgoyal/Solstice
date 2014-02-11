using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(0, Screen.width, Input.mousePosition.x));
		//print (Input.mousePosition.x);
		renderer.material.SetFloat("_Cutoff", Mathf.InverseLerp(99, 0, Utilities.saludBar));
		
	}
}
