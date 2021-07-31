using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int direction = 1;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection(){
        direction*=-1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,12*direction);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(direction == 1){
            if(col.gameObject.tag == "Enemy"){
                col.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }  
        }else{
            if(col.gameObject.tag == "Player"){
                col.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }   
        }
           
    }
}
