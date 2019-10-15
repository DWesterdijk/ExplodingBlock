using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObject : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSys;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kaboom")
        {
            Debug.Log("kaboom");
            _particleSys.gameObject.SetActive(true);
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
