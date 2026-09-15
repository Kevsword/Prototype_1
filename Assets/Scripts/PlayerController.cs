using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float _speed = 20.0f;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _verticalInput;

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        transform.Translate(Vector3.forward * _verticalInput * Time.deltaTime * _speed);
        //Rotates the vehicle
        transform.Rotate(Vector3.up * _horizontalInput * Time.deltaTime * _turnSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Get the horizontal input from Input Action
        _horizontalInput = context.ReadValue<Vector2>().x;
        //Get the vertical input from Input Action
        _verticalInput = context.ReadValue<Vector2>().y;
    }
}
