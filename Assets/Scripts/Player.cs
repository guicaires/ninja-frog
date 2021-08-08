using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(x, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
}
