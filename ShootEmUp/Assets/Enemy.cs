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
    public GameObject bullet, explosion, healthObject;
    public int score;

    public bool isCircularDirection;
    public float radius;
    private float timeCounter = 0;
    private float x, y, z;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate/-2,fireRate/2));
        InvokeRepeating("Shoot", fireRate, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
       if(isCircularDirection){
            x = Mathf.Cos(timeCounter * Mathf.PI/180) * radius + xSpeed;
            z = Mathf.Sin(timeCounter * Mathf.PI / 180) * radius - ySpeed;  
            timeCounter += 1;
            rb.velocity = new Vector3(x, z, ySpeed); 
       }else{
            rb.velocity = new Vector2(xSpeed, ySpeed*-1); 
       } 
      
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag =="Player"){
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }            
    }

    void Die(){            
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }

    public void Damage(){
        health--;
        if(health == 0){
            if((int)Random.Range(0,5) == 0){
                Instantiate(healthObject, transform.position, Quaternion.identity);
            }
            Instantiate(explosion, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Destroy(gameObject);
        }
    }

    void Shoot(){
        GameObject temp = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }
}
