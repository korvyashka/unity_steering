using UnityEngine;
using System.Collections;

public class ArriveComponent : SteeringComponent {
	
	public Vector2 target;
	public float maxAccleleration = 3f;
	public float maxSpeed = 5f;
	
	public float targetRadius = 1f;
	public float slowRadius = 5f;
	
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
		Vector2 direction = target - rigid.position;
		float distance = direction.magnitude;
		float desiredSpeed;
		if (distance < targetRadius)
			desiredSpeed = 0;
		
		if (distance > slowRadius)
			desiredSpeed = maxSpeed;
		else 
			desiredSpeed = maxSpeed * distance/slowRadius;
			
		Vector2 desiredVelocity = direction.normalized * desiredSpeed;
		Vector2 linear = desiredVelocity - rigid.velocity;
		linear /= timeToTarget;
		
		if (linear.magnitude > maxAccleleration)
			linear = linear.normalized * maxAccleleration;
		
		float angle = Mathf.Rad2Deg * (Mathf.Atan2(-desiredVelocity.x, desiredVelocity.y));
		
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		return new SteeringOutput(linear, 0);
	} 
}
