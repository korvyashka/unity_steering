using UnityEngine;
using System.Collections;

[System.Serializable]
public class SeekKinematic: Kinematic{
	
	public Vector2 target;
	public float maxSpeed = 1f;
	public float rotationSpeed = 150f;
	public override KinematicOutput getOutput(Vector2 character, float rotation){
		Vector2 velocity = target - character;
		velocity = velocity.normalized;
		velocity *= maxSpeed;
		
		float desiredRotation = rotation;
		if (velocity.magnitude > 0) 
			desiredRotation = GetVelocityAlignedRotation(velocity, rotation);
		
		float angularVelocity = -rotationSpeed;
		if (desiredRotation > rotation)
			angularVelocity = rotationSpeed;
			 
		
		return new KinematicOutput(velocity, angularVelocity);
	}
}
