using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

	private bool isActive;
	private bool isHighlighted;

	private GameObject reticle;
	private Vector3 objectLastPosition;
	private Vector3 objectVelocity;

	// Use this for initialization
	void Start () {
		isActive = false;
		isHighlighted = false;
		reticle = GameObject.Find ("GvrReticlePointer");
	}

	// Update is called once per frame
	void Update () {
		if (isActive) {
			FollowPointer ();
			CalculateObjectVelocity ();
		}
		if (GvrController.ClickButtonDown && isHighlighted) {
			ActivateObject();
		}
		if (GvrController.ClickButtonUp) {
			InactivateObject ();
			ThrowObject ();
		}
	}

	public void HighlightObject() {
		isHighlighted = true;
	}

	public void ActivateObject() {
		isActive = true;
	}

	public void InactivateObject() {
		isHighlighted = false;
		isActive = false;
	}

	public void FollowPointer() {
		Ray ray = new Ray (reticle.transform.position, reticle.transform.forward);
		transform.position = ray.GetPoint (6.5f);
	}

	private void CalculateObjectVelocity() {
		objectVelocity = (transform.position - objectLastPosition) / Time.fixedDeltaTime;
		objectLastPosition = transform.position;
	}

	public void ThrowObject() {
		float velocityMultiplier = 2.0f;
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (
			objectVelocity.x * velocityMultiplier,
			objectVelocity.y * velocityMultiplier,
			objectVelocity.z * velocityMultiplier,
			ForceMode.Force
		);
	}
		
}
