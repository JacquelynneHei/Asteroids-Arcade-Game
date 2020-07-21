using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D body2D;
    public float pushForce;

    public float destroyDelay;

    void Start()
    {
        //Get Rigidbody from gameobject
        body2D = GetComponent<Rigidbody2D>();

        //add force to the bullet, pushes bullet forward
        body2D.AddForce(transform.up * pushForce);

        Destroy(this.gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<AsteroidController>())
        {
            //destroy the asteroid
            Destroy(collision.gameObject);

            //decrease the number of asteroids in the level
            GameManager.instance.asteroidsInLevel--;

            //destory the bullet
            Destroy(this.gameObject);
        }
    }
}
