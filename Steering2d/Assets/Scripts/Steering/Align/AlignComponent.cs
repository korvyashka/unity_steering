using UnityEngine;
using System.Collections;

public class AlignComponent : SteeringComponent {
	// all public angles/accelerations in rad
	public float target;
	public float maxAngularAcceleration = 2f;
	public float maxAngularSpeed = 1f;
	
	// Considered aligned
	public float targetRadius = 0.1f;

	// Starting to slow down.
	public float slowRadius = 0.5f;
	
	// Slowing koef
	public float timeToTarget = 0.1f;
	Rigidbody2D rigid;
	
	void Awake() {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override SteeringOutput getOutput(){
		float rotationDiff = Mathf.DeltaAngle(rigid.rotation, target * Mathf.Rad2Deg) * Mathf.Deg2Rad;

		float absRotationDiff = Mathf.Abs(rotationDiff);

		float desiredRotationSpeed = 0f; 
		if (absRotationDiff < targetRadius)
			desiredRotationSpeed = 0;
		
		if (absRotationDiff > slowRadius){
			desiredRotationSpeed = maxAngularSpeed;
			
		}
		else{
			desiredRotationSpeed = maxAngularSpeed * absRotationDiff / slowRadius;
		}
		
		desiredRotationSpeed *= rotationDiff / absRotationDiff;

		float angular = desiredRotationSpeed - rigid.angularVelocity * Mathf.Deg2Rad;
		angular /= timeToTarget;

		float absAngular = Mathf.Abs(angular);
		if (absAngular > maxAngularAcceleration){
			angular /= absAngular;
			angular *= maxAngularAcceleration;
		}

	    return new SteeringOutput(Vector2.zero, angular);
	} 
}
