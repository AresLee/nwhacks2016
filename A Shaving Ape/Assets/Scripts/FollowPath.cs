using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

	public Path path;
	public float Speed = 1;
	public float MaxDistancToGoal = 0.1f;

	private IEnumerator<Transform> _currentPoint;

	public void Start(){
		if (path == null)
			return;
		_currentPoint = path.GetPathEnumerator ();
		_currentPoint.MoveNext ();

		if (_currentPoint.Current == null)
			return;
		transform.position = _currentPoint.Current.position;
	}

	public void Update(){
		if (_currentPoint == null || _currentPoint.Current == null)
			return;
		
		transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);

		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < MaxDistancToGoal * MaxDistancToGoal)
			_currentPoint.MoveNext ();
	}
}
