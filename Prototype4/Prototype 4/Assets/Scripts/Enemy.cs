using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    public float eSpeed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        eSpeed = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
       enemyRb.AddForce(lookDirection * eSpeed);
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
