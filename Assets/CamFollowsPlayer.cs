using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public Transform LookAtTarget;
    public float damper;
    public float lookatdamper;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, damper * Time.deltaTime);
        transform.LookAt(LookAtTarget);
    }
}