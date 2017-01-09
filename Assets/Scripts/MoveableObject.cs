using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

	private bool isPickedUp;
	private bool isHighlighted;
	private bool isGravityEnabled;

	private GameObject reticle;
	private Rigidbody rb;

	private Vector3 objectLastPosition;
	private Vector3 objectVelocity;

	void Start () {
		isPickedUp = false;
		isHighlighted = false;
		reticle = GameObject.Find ("GvrReticlePointer");
		rb = GetComponent<Rigidbody> ();
		isGravityEnabled = rb.useGravity;
	}
		
	void Update () {
		if (isPickedUp) {
			FollowPointer ();
			if (isGravityEnabled) {
				CalculateObjectVelocity ();
			}
		}
	}

	public void HighlightObject() {
		isHighlighted = true;
	}

	public void PickUpObject() {
		isPickedUp = true;
	}

	public void LetGoOfObject() {
		isHighlighted = false;
		isPickedUp = false;
		if (isGravityEnabled) {
			AddMomentumToObject ();
		}
	}

	public void FollowPointer() {
		Ray ray = new Ray (reticle.transform.position, reticle.transform.forward);
		transform.position = ray.GetPoint (7.0f);
	}

	private void CalculateObjectVelocity() {
		objectVelocity = (transform.position - objectLastPosition) / Time.fixedDeltaTime;
		objectLastPosition = transform.position;
	}

	public void AddMomentumToObject() {
		float velocityMultiplier = 2.0f;
		rb.AddForce (
			objectVelocity.x * velocityMultiplier,
			objectVelocity.y * velocityMultiplier,
			objectVelocity.z * velocityMultiplier,
			ForceMode.Force
		);
	}
		
}
