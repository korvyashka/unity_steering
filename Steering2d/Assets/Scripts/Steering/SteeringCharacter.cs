using UnityEngine;
using System.Collections;

public class SteeringCharacter : MonoBehaviour {
	public float max_speed = 5f;
	SteeringComponent steering;
	Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		steering = gameObject.GetComponent<SteeringComponent>();
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SteeringOutput output = steering.getOutput();
		
		rigid.velocity += output.linear;
		rigid.angularVelocity += output.angular;
		
		if (rigid.velocity.magnitude > max_speed)
		{
			rigid.velocity = rigid.velocity.normalized * max_speed;
		}
	}
}
