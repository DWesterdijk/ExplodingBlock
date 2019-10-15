using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpoweredGravity : MonoBehaviour
{
    public float _forcePower = 100f;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.gameObject.transform.forward = this.gameObject.transform.forward;
            Vector3 _forwardForce = transform.forward;
            other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _forcePower);
        }
    }
}
//public class EmpoweredGravity : MonoBehaviour
//{
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.GetComponent<Rigidbody>() != null)
//        {
//            other.gameObject.transform.forward = this.gameObject.transform.forward;
//        }
//    }
//
//    private void OnTriggerStay(Collider other)
//    {
//        if (other.GetComponent<Rigidbody>() != null)
//        {
//            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
//        }
//    }
//}
