using UnityEngine;
using System.Collections;

public class DeleteOnCollision : MonoBehaviour {

	bool goingDown = false;

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Razor") {
			DestroyObject (gameObject);
			//goingDown = true;
		}
	}

	//void Update(){
		//if (goingDown) {
			//Vector3 newPosition = gameObject.transform.position;
			//newPosition.y = newPosition.y--;
			//gameObject.transform.position = newPosition;
		//}
	//}
}
