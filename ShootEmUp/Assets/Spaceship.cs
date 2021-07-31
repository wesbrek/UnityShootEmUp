using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    float fireElapsedTime = 0;
    public float fireDelay = 0.2f;
    GameObject a,b;
    public GameObject bullet;
    Rigidbody2D rb;
    public float speed;
    int health =3;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical")*speed));

        fireElapsedTime += Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && fireElapsedTime >= fireDelay){
            fireElapsedTime = 0;
            Shoot();
        }      
    }

    public void Damage(){
        if(health == 0){
            Destroy(gameObject);
        }
    }

    void Shoot(){
        Instantiate(bullet,a.transform.position,Quaternion.identity);
        Instantiate(bullet,b.transform.position,Quaternion.identity);
    }
}
