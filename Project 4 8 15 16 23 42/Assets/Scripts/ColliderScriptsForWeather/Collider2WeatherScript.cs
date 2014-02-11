using UnityEngine;
using System.Collections;
public class Collider2WeatherScript : MonoBehaviour {
public GameObject particle;
public GameObject player;
public int fightSound;
// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {

}

void OnTriggerEnter(Collider collider) {
if (collider.gameObject.Equals(player)) {
	if (!name.Equals("Collider8")) {
		particle.particleSystem.enableEmission = true;
	}
	SoundTrackControler.track = fightSound;
}
}
}