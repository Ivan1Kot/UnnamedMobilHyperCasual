using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public InputAction Move;
    public InputAction Jump;
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothVelocity = 0.1f;
    float turnSmoothTime;
    float gravity = 30f;
    Vector3 direction;
    bool isJumped;

    private void Awake()
    {
        Jump.performed += ctx => DoJump();
    }

    private void OnEnable()
    {
        Jump.Enable();
        Move.Enable();
    }

    private void OnDisable()
    {
        Jump.Disable();
        Move.Disable();
    }

    public void Update()
    {
        direction = new Vector3(Move.ReadValue<Vector2>().x, 0f, Move.ReadValue<Vector2>().y);

        if(isJumped)
        {
            direction.y = 20f;
            isJumped = false;
        }

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * speed * Time.deltaTime);
    }

    public void DoJump()
    {
        isJumped = true;
    }
}