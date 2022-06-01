using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOnPlayer : MonoBehaviour
{
    public Transform Player;
    public GameObject ShieldOn;
    void Start()
    {
        ShieldOn.SetActive(false);
    }

    void Update()
    {
        ShieldOn.transform.position = new Vector2(Player.position.x, 3.5f);
    }


}
