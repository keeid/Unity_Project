using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject wall;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            wall.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
