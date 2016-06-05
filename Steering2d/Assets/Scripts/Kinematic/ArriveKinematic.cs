using UnityEngine;
using System.Collections;

[System.Serializable]
public class ArriveKinematic: Kinematic{
	
	public Vector2 target;
	public float maxSpeed = 5f;
	
	public float radius = 0.1f;
	
	public float timeToTarget = 0.25f;
	
	public float rotationSpeed = 150f;
	
	public override KinematicOutput getOutput(Vector2 character, float rotation){
		Vector2 velocity = target - character;
		
		if (velocity.magnitude < radius)
			return null;
		
		velocity /= timeToTarget;
		
		if (velocity.magnitude > maxSpeed)
		{	
			velocity = velocity.normalized;
			velocity *= maxSpeed;
		}
		
		float desiredRotation = rotation;
		if (velocity.magnitude > 0) 
			desiredRotation = GetVelocityAlignedRotation(velocity, rotation);
		
		float angularVelocity = -rotationSpeed;
		if (desiredRotation > rotation)
			angularVelocity = rotationSpeed;
		
		return new KinematicOutput(velocity, angularVelocity);
	}
}