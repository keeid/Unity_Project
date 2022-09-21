using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankRotate : MonoBehaviour
{
    public float r= 0;
    public float rotateSpeed = 50;
    void Start()
    {
       
    }

    void Update()
    {
        r = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        transform.Rotate(0,r,0);
    }
}
