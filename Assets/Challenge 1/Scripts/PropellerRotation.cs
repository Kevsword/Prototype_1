using System.Runtime.CompilerServices;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    private float _rotationSpeed = 500.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }
}
