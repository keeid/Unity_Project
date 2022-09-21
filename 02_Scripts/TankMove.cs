using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public float x, y, z = 0;
    public float speed = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        y = Input.GetAxis("Jump") * Time.deltaTime * speed;
        transform.Translate(x,y,z);
    }
}
