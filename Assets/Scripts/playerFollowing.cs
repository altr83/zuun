using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollowing : MonoBehaviour {

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Vector3 offset;

	public float smoothSpeed;

	private void FixedUpdate() {
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
		transform.LookAt(target);
	}
}
