using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    private float _speed = 15.0f;
    private float _rotationSpeed = 50.0f;
    private float _verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * _verticalInput * _rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _verticalInput = context.ReadValue<Vector2>().y;
    }
}
