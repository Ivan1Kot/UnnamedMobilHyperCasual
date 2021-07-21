using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] private InputAction _controls;

    [SerializeField] private Transform _centerOfMass;

    [SerializeField] private Wheel[] _wheels;

    [SerializeField] private float _motorTorgue = 100f;
    [SerializeField] private float _maxSteer = 20f;
    [SerializeField] private float _steerSpeed = 20f;

    public float Steer { get; set; }
    public float Throttle { get; set; }

    private Rigidbody _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.centerOfMass = _centerOfMass.localPosition;
    }

    private void Update()
    {
        Steer = _controls.ReadValue<Vector2>().x;
        Throttle = _controls.ReadValue<Vector2>().y;
        foreach (var wheel in _wheels)
        {
            wheel.SteerAngle = Steer * _maxSteer;
            wheel.SteerSpeed = _steerSpeed;
            wheel.Torgue = Throttle * _motorTorgue;
        }
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}