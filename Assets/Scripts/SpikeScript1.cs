using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript1 : MonoBehaviour
{
    float timer;

    public GameObject SpikeCopy;
    public Rigidbody2D spikerb;
    public GameObject ShieldOn;
    public GameObject Shield;
    
    float randoX;
    float randoY;

    public AudioSource shildsound;

    private Vector2 whereToSpawn;

    public void Start()
    {
        randoX = Random.Range(-15.5f, 15.5f);
        randoY = Random.Range(21f, 50f);
        SpikeCopy.transform.position = new Vector2(randoX, randoY);
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UnderFloor")
        {
            spikerb.freezeRotation = true;
            randoX = Random.Range(-15.5f, 15.5f);
            randoY = Random.Range(21f, 50f);
            whereToSpawn = new Vector2(randoX, randoY);
            spikerb.velocity = new Vector2(0, 0);
            spikerb.velocity = new Vector2(0, timer * -0.12f);
            this.transform.position = whereToSpawn;
            //Instantiate(SpikeCopy, whereToSpawn, Quaternion.identity);
            //Destroy(SpikeCopy);

        }

        if (collision.gameObject.tag == "OnPlayerShield")
        {

            SpikeCopy.transform.position = new Vector2(randoX, randoY);
            StartCoroutine(SpawnShieldDelay());

            shildsound.mute = false;
            shildsound.Play();
            ShieldOn.SetActive(false);
            
        }
    }

    IEnumerator SpawnShieldDelay()
    {
        yield return new WaitForSeconds(5f);
        randoX = Random.Range(-15.5f, 15.5f);
        randoY = Random.Range(21f, 50f);
        Shield.transform.position = new Vector2(randoX, randoY);
        Shield.SetActive(true);
    }
}