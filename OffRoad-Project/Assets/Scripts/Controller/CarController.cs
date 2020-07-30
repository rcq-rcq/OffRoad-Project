using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{
	public InputManager IM;

	[SerializeField]
	List<WheelCollider> _throttleWheels;
	[SerializeField]
	List<WheelCollider> _steeringWheels;

	public float Torque = 10000f;
	public float Acceleration = 10f;
	public float Deceleration = 8f;
	public float MaxTurn = 20f;

	public float Speed;

	[SerializeField]
	Rigidbody _rb;

	public Transform CenterOfMass;

	private void Start()
	{
		IM = GetComponent<InputManager>();
		_rb = GetComponent<Rigidbody>();

		if(CenterOfMass != null)
		{
			_rb.centerOfMass = CenterOfMass.position;
		}
	}

	private void FixedUpdate()
	{

		foreach (WheelCollider wheel in _throttleWheels)
		{
			wheel.motorTorque = Torque * Time.deltaTime * Acceleration * IM.ThrottleInput;

			if (IM.ThrottleInput == 0)
			{
				wheel.brakeTorque = Torque * Deceleration * Time.deltaTime;
			}
			else
			{
				wheel.brakeTorque = 0f;
			}
		}

		foreach(WheelCollider wheel in _steeringWheels)
		{
			wheel.steerAngle = MaxTurn * IM.SteeringInput;
		}

		Speed = _rb.velocity.magnitude;
	}
}
