using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public GameObject Wheelcollider;
    

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localRotation = Wheelcollider.GetComponent<WheelCollider>().transform.localRotation;
    }
}
