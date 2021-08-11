using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private BoxCollider2D boxColl;
    private TargetJoint2D targetJoint;

    private int DESTROY_LAYER = 9;

    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        targetJoint = GetComponent<TargetJoint2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == DESTROY_LAYER)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        boxColl.isTrigger = true;
        targetJoint.enabled = false;
    }
}
