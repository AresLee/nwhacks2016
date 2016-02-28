using UnityEngine;
using System.Collections;

public class HitApeFaceSound : MonoBehaviour {
	public AudioClip firstRoar;
	public AudioClip secondRoar;
	public AudioClip firstMiss;
	public AudioClip secondMiss;
	public AudioClip firstShave;
	public AudioClip secondShave;
    public GameObject gameManager;

	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource>();
        
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "ApeFace") {
            //gameManager.penalty();
			if (Random.value > 0.5f) {
				source.PlayOneShot (firstRoar, 1.6f);
			} else {
				source.PlayOneShot (secondRoar, 1.6f);
			}
		} else if (col.gameObject.tag == "MissedZone") {
			if (Random.value > 0.5f) {
				source.PlayOneShot (firstMiss, 1.0f);
			} else {
				source.PlayOneShot (secondMiss, 1.0f);
			}
		} else if (col.gameObject.tag == "Hairball") {
			if (Random.value > 0.5f) {
				source.PlayOneShot (firstShave, 1.0f);
			} else {
				source.PlayOneShot (secondShave, 1.0f);
			}
		}
	}
}
