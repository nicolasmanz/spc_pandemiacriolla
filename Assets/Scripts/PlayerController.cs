using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprit;
    public GameObject alcohol;
    public float speed;
    public float jumpSpeed;
    public float fever = 0;
    public float maxFever = 43;
    public float alcoholAmount = 100;
    public float maxAlcoholAmount = 200;
    public Image feverUI;
    public Text alcoholUI;
    public Text feverText;
    public Image bloodScreen;
    public bool dead = false;
    private bool canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprit = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb2d.AddForce(new Vector3(speed, 0, 0), ForceMode2D.Impulse);
                anim.SetBool("walking", true);
                sprit.flipX = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb2d.AddForce(new Vector3(-speed, 0, 0), ForceMode2D.Impulse);
                anim.SetBool("walking", true);
                sprit.flipX = true;
            }
            else
            {
                anim.SetBool("walking", false);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.F) && alcoholAmount>0)
            {
                alcoholAmount -= 1;
                alcoholAmount = Mathf.Clamp(alcoholAmount, 0, maxAlcoholAmount);
                GameObject alcoholGO = Instantiate(alcohol, transform.position + new Vector3(1, 0.5f, 0), Quaternion.identity);
                if(sprit.flipX) alcoholGO.GetComponent<AlcoholBullet>().SetInvertedSpeed();
            }
        }

        feverUI.fillAmount = fever;
        float feverAm = Mathf.Round(36 + 10 * fever);
        feverText.text = Mathf.Clamp(feverAm, 0, 45)+"C";
        Color bloodScreenColor = bloodScreen.color;
        bloodScreenColor.a = fever - 0.1f;
        bloodScreen.color = bloodScreenColor;
        alcoholUI.text = alcoholAmount.ToString();

        if (feverAm >= maxFever && !dead)
        {
            canMove = false;
            dead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddAlcoholAmount(int amount)
    {
        alcoholAmount += amount;
    }

    public void ReceiveDamage(float damage)
    {
        fever += damage;
    }
    
}
