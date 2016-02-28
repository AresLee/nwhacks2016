using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour 
{
	public GameObject hairballPrefab;
	public Stopwatch SW = new Stopwatch ();
	public float radius;
	public int hairballcount = 0;
	public int maxhairball;

	// Use this for initialization
	void Start () 
	{
		CreateHairBalls ();
		InitHairballText ();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (hairballcount < maxhairball) 
		{
			SW.Start ();

			Text stopwatchText = GameObject.FindGameObjectWithTag ("Stopwatch Text").GetComponent<Text> ();

			if (hairballcount == 0) 
			{
				SW.Stop ();
			}

			float elapsedTime = 0.001f * SW.ElapsedMilliseconds;

			if (elapsedTime < 10 && elapsedTime.ToString ().Length > 5) {
				stopwatchText.text = "Elapsed Time: " + elapsedTime.ToString ().Substring (0, 4);
			} else if (elapsedTime > 0 && elapsedTime.ToString ().Length > 6) {
				stopwatchText.text = "Elapsed Time: " + elapsedTime.ToString ().Substring (0, 5);
			} else {
				stopwatchText.text = "Elapsed Time: " + elapsedTime.ToString ();
			}
		}
	}

	void CreateHairBalls()
	{
		for (float y = 0; y > -5f; y = y - 0.5f) 
		{
			for (float x = -5f; x < 5f; x = x + 0.5f) 
			{
				if((x < -1 || x > 1) || (y > -1 || y < -2)) 
				{
					float yCalc;
					yCalc = Mathf.Cos (y / radius);
					Instantiate (hairballPrefab, new Vector3 (x * yCalc, y, -(Mathf.Cos (x / radius)) * radius * yCalc), Quaternion.identity);

					hairballcount += 1;
				}

			}
		}

		maxhairball = hairballcount;
	}

	void InitHairballText()
	{
		Text hairballText = GameObject.FindGameObjectWithTag ("Hairball Text").GetComponent<Text> ();
		hairballText.text = "Hairballs Left: " + hairballcount.ToString();
	}
}
