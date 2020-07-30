using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public float ThrottleInput;
	public float SteeringInput;

	public bool BrakeInput;

	private void Update()
	{
		ThrottleInput = Input.GetAxis("Vertical");
		SteeringInput = Input.GetAxis("Horizontal");
		BrakeInput = (Input.GetKey(KeyCode.Space));

		if(ThrottleInput <=.1f && ThrottleInput >= -.1f)
		{
			ThrottleInput = 0;
		}
		if (SteeringInput <= .1f && SteeringInput >= -.1f)
		{
			SteeringInput = 0;
		}
	}
}
