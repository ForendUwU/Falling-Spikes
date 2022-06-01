using System;
using System.Collections;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    public Rigidbody2D rb = new Rigidbody2D();

    public GameObject gameOverPanel;
    public GameObject shieldOnPlayer;
    public GameObject shield;

    public AudioSource death;
    public AudioSource shieldsound;
    public AudioSource _dashsound;

    public int xVelocity = 5;

    bool isDashing;
    float doubleTapTime;
    public float dashDistance = 100f;
    KeyCode lastKeycode;

    public GameObject dashEffect;

    private float timer;

    private Touch theTouch;

    private void Start()
    {
        rb.position = new Vector2(0, 2f);
        gameOverPanel.SetActive(false);
   
    }

    
    private void Update()
    {
        timer += Time.deltaTime;

        if (Time.timeScale != 0)
        {


            if (Input.GetKeyDown(KeyCode.A))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.A)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.A;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.D)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.D;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.Mouse0)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.Mouse0;
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.Mouse1)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.Mouse1;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.LeftArrow)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(-1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.LeftArrow;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (doubleTapTime > Time.time && lastKeycode == KeyCode.RightArrow)
                {
                    Instantiate(dashEffect, transform.position, Quaternion.identity);
                    StartCoroutine(Dash(1f));
                }
                else
                {
                    doubleTapTime = Time.time + 0.25f;
                }

                lastKeycode = KeyCode.RightArrow;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) || Input.GetMouseButton(0))
            {
                rb.velocity = new Vector2(-xVelocity - timer * 0.05f, 0);

            }
            else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow) || Input.GetMouseButton(1))
            {
                rb.velocity = new Vector2(xVelocity + timer * 0.05f, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            if (!shieldOnPlayer.activeInHierarchy)
            {
                
                if (!isDashing)
                {
                    death.mute = false;
                    death.Play();
                    gameOverPanel.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }

        if (collision.gameObject.tag == "Shield")
        {
            shieldsound.mute = false;
            shieldsound.Play();

            shieldOnPlayer.SetActive(true);
            shield.SetActive(false);

        }
    }


    private IEnumerator Dash(float direction) {
        _dashsound.mute = false;
        _dashsound.Play();
        isDashing = true;
        rb.velocity = new Vector2(xVelocity*3*direction, 0f);
        //rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        //float gravity = rb.gravityScale;
        //rb.gravityScale = 0;
        yield return new WaitForSeconds(0.13f);
        isDashing = false;
        //rb.gravityScale = gravity;
    }

}