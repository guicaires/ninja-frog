using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherries : MonoBehaviour
{
    public int score;
    public GameObject collectedAnim;
    private SpriteRenderer spriteRender;
    private CircleCollider2D circle;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            circle.enabled = false;
            spriteRender.enabled = false;
            collectedAnim.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
