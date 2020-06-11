using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyController : MonoBehaviour
{
    public float damage = 0.1f;
    private GameObject covid;

    private void Start()
    {
        covid = Resources.Load("Covid") as GameObject;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerController>().ReceiveDamage(damage * Time.deltaTime);
        }
    }

    public void CreateMiniCovid()
    {
        Destroy(gameObject);
        if (transform.localScale.x < 0.5f) return;
        for (int i = 0; i < 2; i++)
        {
            GameObject miniCovid = Instantiate(
                covid, 
                transform.position, 
                Quaternion.identity
            );
            miniCovid.transform.localScale = transform.localScale * 0.5f;
            miniCovid.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(UnityEngine.Random.Range(-50.0f, 50.0f), UnityEngine.Random.Range(-50.0f, 50f)),
                ForceMode2D.Impulse
            );
        }
    }
}
