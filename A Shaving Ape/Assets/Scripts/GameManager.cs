using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject hairballPrefab;

	public float radius = 7.5f;

	// Use this for initialization
	void Start () {
		for (float y = 0; y > -7f; y = y - 0.75f) {
			for (float x = -7.5f; x < 7.5f; x = x + 0.75f) {
				float yCalc;
				yCalc = Mathf.Cos (y/radius);
				Instantiate (hairballPrefab, new Vector3 (x * yCalc, y, -(Mathf.Cos (x / radius)) * radius * yCalc), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
