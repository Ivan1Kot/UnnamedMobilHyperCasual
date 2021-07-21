using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private bool _steer;
    [SerializeField] private bool _invertSteer;
    [SerializeField] private bool _power;

    [SerializeField] private WheelCollider _wheelCollider;
    [SerializeField] private Transform _wheelTransform;

    public float SteerAngle { get; set; }
    public float SteerSpeed { get; set; }
    public float Torgue { get; set; }

    private void Update()
    {
        _wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        _wheelTransform.position = pos;
        _wheelTransform.rotation = rot;
    }

    private void FixedUpdate()
    {
        if(_steer)
        {
            _wheelCollider.steerAngle = Mathf.Lerp(_wheelCollider.steerAngle, SteerAngle * (_invertSteer ? -1 : 1), SteerSpeed * Time.deltaTime);
        }
        if(_power)
        {
            _wheelCollider.motorTorque = Torgue;
        }
    }
}