using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horsePower;
    [SerializeField] private float _turnSpeed;
    private float _horizontalInput;
    private float _verticalInput;

    private Rigidbody _rb;
    [SerializeField] private GameObject _centerOfMass;

    private float _speed;
    [SerializeField] private TextMeshProUGUI _speedometerText;

    [SerializeField] private TextMeshProUGUI _rpmText;
    private float _rpm;

    [SerializeField] private List<WheelCollider> _wheels;
    [SerializeField] private int _wheelsOnGround;

    private void Start()
    {
        // Get rigidbody component
        _rb = GetComponent<Rigidbody>();
        // Get position for the center of mass
        _rb.centerOfMass = _centerOfMass.transform.position;
    }

    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            Movement();
            UpdateSpeedometer();
            UpdateRPM();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //Get the horizontal input from Input Action
        _horizontalInput = context.ReadValue<Vector2>().x;
        //Get the vertical input from Input Action
        _verticalInput = context.ReadValue<Vector2>().y;
    }

    private void Movement()
    {
        //Move the vehicle forward
        _rb.AddRelativeForce(Vector3.forward * _verticalInput * _horsePower);
        //Rotates the vehicle
        transform.Rotate(Vector3.up * _horizontalInput * Time.deltaTime * _turnSpeed);
    }

    private void UpdateSpeedometer()
    {
        // Round speed decimals and calculate mph to show it
        _speed = Mathf.Round(_rb.linearVelocity.magnitude * 2.237f); // 3.6 for kph
        _speedometerText.SetText("Speed: " + _speed + "mph");
    }

    private void UpdateRPM()
    {
        // Round speed decimals and calculate rmp to show it
        _rpm = Mathf.Round((_speed % 30) * 40);
        _rpmText.SetText("RPM: " + _rpm);
    }

    private bool IsOnGround()
    {
        // Detect each wheel to see if it's grounded
        _wheelsOnGround = 0;
        foreach (WheelCollider wheel in _wheels)
        {
            if (wheel.isGrounded)
            {
                _wheelsOnGround++;
            }
        }

        // Return true or false depending if all wheels are grounded or not
        if (_wheelsOnGround == 4)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
