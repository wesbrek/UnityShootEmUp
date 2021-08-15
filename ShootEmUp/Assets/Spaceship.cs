using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    
    GameObject a,b;
    Rigidbody2D rb;
    float fireElapsedTime = 0;
    int health =3;
    public GameObject bullet, explosion;
    public float speed;
    public float fireDelay = 0.2f;

    float x,y;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Health", health);
        Vector3 pos = transform.position;
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

        x = Mathf.Round(transform.position.x * 100.0f) * 0.01f;
        y = Mathf.Round(transform.position.y * 100.0f) * 0.01f;
        PlayerPrefs.SetFloat("posX", x);
        PlayerPrefs.SetFloat("posY", y);
    }

    public void Damage(){
        health--;
        PlayerPrefs.SetInt("Health", health);
        StartCoroutine(Blink());
        if(health == 0){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }

    IEnumerator Blink(){
        GetComponent<SpriteRenderer>().color = new Color(1,0,0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1);
    }

    void Shoot(){
        Instantiate(bullet,a.transform.position,Quaternion.identity);
        Instantiate(bullet,b.transform.position,Quaternion.identity);
    }

    public void AddHealth(){
        health++;
        PlayerPrefs.SetFloat("Health", health);
    }
}
