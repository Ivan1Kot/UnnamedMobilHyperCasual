using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform Target;
    public float damper;
    public Vector3 Offset;

    private void Awake()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, damper * Time.deltaTime);
    }
}