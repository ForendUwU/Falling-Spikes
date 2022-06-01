using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public Rigidbody2D shieldrb;
    public GameObject shield;
    public GameObject shieldOn;

    float randoY;
    float randoX;

    Vector2 whereToSpawn;
    void Start()
    {
        randoX = Random.Range(-15.5f, 15.5f);
        randoY = Random.Range(21f, 50f);
        shieldrb.velocity = new Vector2(0, 0);
        whereToSpawn = new Vector2(randoX, randoY);
        this.transform.position = whereToSpawn;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UnderFloor")
        {
            StartCoroutine(SpawnShieldDelay());
        }
    }

    IEnumerator SpawnShieldDelay()
    {
        randoX = Random.Range(-15.5f, 15.5f);
        randoY = Random.Range(21f, 50f);
        yield return new WaitForSeconds(5f);
        whereToSpawn = new Vector2(randoX, randoY);
        shieldrb.velocity = new Vector2(0, 0);
        this.transform.position = whereToSpawn;
    }
}
