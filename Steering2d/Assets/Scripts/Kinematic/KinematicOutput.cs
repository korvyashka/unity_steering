using UnityEngine;
using System.Collections;

public class KinematicOutput{

	public Vector2 desiredVelocity;
	public float desiredAngularVelocity;
	
	public KinematicOutput(Vector2 desiredVelocity, float desiredAngularVelocity){
		this.desiredVelocity = desiredVelocity;
		this.desiredAngularVelocity = desiredAngularVelocity; 
	}
	
	public Vector2 linear(Vector2 current){
		return desiredVelocity - current;
	}
	
	public float angular(float current){
		return desiredAngularVelocity - current;
	}
}
