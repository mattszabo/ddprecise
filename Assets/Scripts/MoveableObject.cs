using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

	public GameObject pointer;

	private bool isPickedUp;
	private bool isGravityEnabled;

	private Rigidbody rb;

	private Vector3 objectLastPosition;
	private Vector3 objectVelocity;

	void Start () {
		isPickedUp = false;
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

	public void PickUpObject() {
		isPickedUp = true;
	}

	public void LetGoOfObject() {
		isPickedUp = false;
		if (isGravityEnabled) {
			ApplyMomentumToObject ();
		}
	}

	private void FollowPointer() {
		Ray ray = new Ray (pointer.transform.position, pointer.transform.forward);
		transform.position = ray.GetPoint (7.0f);
	}

	private void CalculateObjectVelocity() {
		objectVelocity = (transform.position - objectLastPosition) / Time.fixedDeltaTime;
		objectLastPosition = transform.position;
	}

	private void ApplyMomentumToObject() {
		float velocityMultiplier = 2.0f;
		rb.AddForce (
			objectVelocity.x * velocityMultiplier,
			objectVelocity.y * velocityMultiplier,
			objectVelocity.z * velocityMultiplier,
			ForceMode.Force
		);
	}
		
}
