using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float damper;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        if(Target == null)
        {
            return;
        }
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, damper*Time.deltaTime);
        //transform.LookAt(LookAtTarget);
    }
}