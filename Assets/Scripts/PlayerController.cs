using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRb;

    public void Velocity(Vector3 _velocity) {velocity = _velocity;}

    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        myRb.MovePosition(myRb.position + velocity * Time.deltaTime);
    }
}
