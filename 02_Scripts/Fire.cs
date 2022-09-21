using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject arrow;
    public GameObject firePos;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject obj1 =Instantiate(bullet,firePos.transform.position,firePos.transform.rotation);

            Destroy(obj1, 5.5f);
        } 
        
        else if (Input.GetMouseButtonDown(1))
        {
            GameObject obj2 = Instantiate(arrow, firePos.transform.position, firePos.transform.rotation);

            Destroy(obj2, 5.5f);
        }
    }
    
}
