using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeleteOnCollision : MonoBehaviour 
{	
	void OnCollisionEnter(Collision coll)
	{		
		if (coll.gameObject.tag == "Razor") 
		{
			GameManager GM = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
			GM.hairballcount -= 1;
			DestroyObject (gameObject);

			Text hairballText = GameObject.FindGameObjectWithTag ("Hairball Text").GetComponent<Text> ();
			hairballText.text = "Hairballs Left: " + GM.hairballcount.ToString();
		}
	}
}
