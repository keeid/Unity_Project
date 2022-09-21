using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float r = 0;
    public float scroll = 100;
    void Start()
    {
        
    }

    void Update()
    {
        r = Input.GetAxis("Mouse ScrollWheel") * 100;
        transform.Rotate(r,0,0);
    }
}
