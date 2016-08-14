using UnityEngine;
using System.Collections;

public class SteeringOutput{

	public Vector2 linear;
	public float angular;
	
	public SteeringOutput(Vector2 linear, float angular){
		this.linear = linear;
		this.angular = angular; 
	}
}
