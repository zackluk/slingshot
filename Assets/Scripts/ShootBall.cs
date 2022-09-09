//using System.Collections;
//using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ShootBall : MonoBehaviour
{

    public float power = 0.05f;
    private Vector3 force;
    private Vector3 initialGrabPosition;
    private Vector3 releasePosition;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnGrab()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        initialGrabPosition = transform.localPosition;
    }

    public void OnRelease()
    {
        releasePosition = transform.localPosition;

        force = new Vector3(initialGrabPosition.x - releasePosition.x, -(initialGrabPosition.y - releasePosition.y),
            initialGrabPosition.z - releasePosition.z);
        
        Shoot();
    }

    void Shoot()
    {
        rb.AddForce(-(force * power), ForceMode.Impulse);
    }
}
