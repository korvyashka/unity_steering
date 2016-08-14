using UnityEngine;
using System.Collections;

public class FleeComponent : SteeringComponent {
	public Vector2 target;
	public float maxAccleleration = 3f;
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
		Vector2 velocity = rigid.position - target;
		velocity = velocity.normalized * maxAccleleration;
		float angle = Mathf.Rad2Deg * (Mathf.Atan2(-velocity.x, velocity.y));
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		return new SteeringOutput(velocity, 0);
	} 
}
