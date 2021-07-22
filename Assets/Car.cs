using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] private InputAction _controlsThrottle;
    [SerializeField] private InputAction _controlsBrakes;
    [SerializeField] private InputAction _controlsSteering;

    [SerializeField] private Transform _centerOfMass;

    [SerializeField] private Wheel[] _wheels;

    [SerializeField] private float _motorTorgue = 100f;
    [SerializeField] private float _brakesTorgue = 10f;
    [SerializeField] private float _maxSteer = 20f;
    [SerializeField] private float _steerSpeed = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }
    public float Brakes { get; set; }

    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.centerOfMass = _centerOfMass.localPosition;

    }

    private void FixedUpdate()
    {
        Steer = _controlsSteering.ReadValue<float>();
        Throttle = _controlsThrottle.ReadValue<float>();
        Brakes = _controlsBrakes.ReadValue<float>();
        foreach (var wheel in _wheels)
        {
            wheel.SteerAngle = Steer * _maxSteer;
            wheel.SteerSpeed = _steerSpeed;
            wheel.Torgue = Throttle * _motorTorgue;
            wheel.BrakesTorgue = _brakesTorgue * Brakes;
        }
    }

    private void OnEnable()
    {
        _controlsThrottle.Enable();
        _controlsSteering.Enable();
        _controlsBrakes.Enable();
    } 
}