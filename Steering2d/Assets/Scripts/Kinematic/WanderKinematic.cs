using UnityEngine;
using System.Collections;

[System.Serializable]
public class WanderKinematic: Kinematic{
	public float maxSpeed = 5f;
	
	public float maxRotation = 20f;
	
	public override KinematicOutput getOutput(Vector2 character, float rotation){
		Vector2 velocity = new Vector2(-Mathf.Sin(rotation * Mathf.Deg2Rad), Mathf.Cos(rotation * Mathf.Deg2Rad)).normalized * maxSpeed;
		float angularVelocity = (Random.value - Random.value) * maxRotation; 
		return new KinematicOutput(velocity, angularVelocity);
	}
}