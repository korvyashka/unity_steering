using UnityEngine;
using System.Collections;

abstract public class Kinematic: System.Object{
	abstract public KinematicOutput getOutput(Vector2 position, float rotation);
	
	protected float GetVelocityAlignedRotation(Vector2 velocity, float rotation) {
		return Mathf.Rad2Deg * (Mathf.Atan2(-velocity.x, velocity.y));
	}

}
