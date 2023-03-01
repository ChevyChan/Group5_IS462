using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class Throw_Object : MonoBehaviour
{
    public Rigidbody rigidbody;
    public bool isHeld = false;
    public Vector3 handPosition;
    public Quaternion handRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (isHeld)
        {
            //No velocity applied when the object is held
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            transform.position = handPosition;
            transform.rotation = handRotation;
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                rigidbody.AddForce(OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch) * 1000f);
                rigidbody.AddTorque(OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch) * 500f);
                isHeld = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            handPosition = transform.position;
            handRotation = transform.rotation;
            isHeld = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            isHeld = false;
        }
    }
}
