using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public float smooth = 2.0f;
    public float rotateAngle = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = Input.GetAxis("Horizontal") * rotateAngle;
        float zRotation = Input.GetAxis("Vertical") * rotateAngle;

        Quaternion bRotation = Quaternion.Euler(xRotation, 0.0f, zRotation);

        transform.rotation = Quaternion.Slerp(transform.rotation,bRotation,Time.deltaTime*smooth);

    }
}
