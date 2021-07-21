using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    //fix rotation of car
    //fix gravity of car

    //raycast
    public InputAction Move;

    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;

    public float airDrag;
    public float groundDrag;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public float turnInputModifier;
    public LayerMask GroundLayer;

    public Rigidbody sphereRB;

    void Start()
    {
        //detach rigidbody from car
        sphereRB.transform.parent = null;
    }

    private void OnEnable()
    {
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
    }

    void Update()
    {
        moveInput = Move.ReadValue<Vector2>().y;
        turnInput = Move.ReadValue<Vector2>().x;
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        //set cars position to sphere
        transform.position = sphereRB.transform.position;

        //set cars rotation
        float newRotation = turnInput * turnSpeed * Time.deltaTime / (Move.ReadValue<Vector2>().y * turnInputModifier);
        transform.Rotate(0, newRotation, 0, Space.World);

        // raycast ground check
        RaycastHit hit;
        int groundLayer = 1;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, groundLayer);

        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

        if (isCarGrounded)
        {
            sphereRB.drag = groundDrag;
        }
        else
        {
            sphereRB.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            //move car
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            //add extra gravity
            sphereRB.AddForce(transform.up * -30);

        }
    }
}