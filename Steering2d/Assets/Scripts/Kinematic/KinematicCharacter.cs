using UnityEngine;
using System.Collections;

public class KinematicCharacter : MonoBehaviour {
	public WanderKinematic kinematic;
	Rigidbody2D rigid;
	
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 updateMovement();
		 
	}
	
	void updateMovement(){
		KinematicOutput output = kinematic.getOutput(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), rigid.rotation);
		
		if (output != null) {
			rigid.velocity += output.linear(rigid.velocity) * Time.deltaTime;
			rigid.angularVelocity += output.angular(rigid.angularVelocity) * Time.deltaTime;
		}
		else{
			rigid.velocity = Vector2.zero;
			rigid.angularVelocity = 0f;
		}
	}
}
