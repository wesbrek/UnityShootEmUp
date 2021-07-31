using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public float health;
    public GameObject bullet;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,15);
        if(!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate/-2,fireRate/2));
        InvokeRepeating("Shoot", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
       rb.velocity = new Vector2(xSpeed, ySpeed*-1); 
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag =="Player"){
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }            
    }

    void Die(){
        Destroy(gameObject);
    }

    public void Damage(){
        health--;
        if(health == 0){
            Destroy(gameObject);
        }
    }

    void Shoot(){
        GameObject temp = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }
}
