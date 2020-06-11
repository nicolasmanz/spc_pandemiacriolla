using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholController : MonoBehaviour
{
    public int amount = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.GetComponent<PlayerController>().AddAlcoholAmount(amount);
        }
    }
}
