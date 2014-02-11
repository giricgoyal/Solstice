using UnityEngine;
using System.Collections;

public class Griffin : MonoBehaviour 
{
	public GameObject g;
	public static bool griffonactive;
	// Use this for initialization
	void Start ()
	{
		g= GameObject.FindGameObjectWithTag("griffon");
		g.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Utilities.currentSeason == Utilities.spring) {
			if(griffonactive)
			{
				g.SetActive(true);
				transform.FindChild ("griffon").animation["takeOff"].wrapMode=WrapMode.Once;
				transform.FindChild ("griffon").animation.CrossFade("takeOff");
				transform.FindChild ("griffon").animation["fly"].wrapMode=WrapMode.Loop;
				transform.FindChild ("griffon").animation.CrossFade("fly");
				Debug.Log ("griffon active");
			    Utilities.griffonTimer -= Time.deltaTime;
				if (Input.GetButtonUp("power3")) {
					g.SetActive(false);
					griffonactive = false;
				}
				print(Utilities.griffonTimer);
				if (Utilities.griffonTimer < 0)
				{
					Debug.Log("griffon deactive");
					griffonactive=false;
					g.SetActive(false);
				}											
				
			}  
		}
		else {
			g.SetActive(false);
		}
	}
}