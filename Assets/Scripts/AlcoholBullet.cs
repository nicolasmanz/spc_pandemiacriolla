using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholBullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 20;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetInvertedSpeed()
    {
        speed *= -1;
    }

    private void Update()
    {
        rb2d.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Covid"))
        {
            other.GetComponent<EnemyController>().CreateMiniCovid();
            Destroy(gameObject);
        }
    }
}
