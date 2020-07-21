using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D body2D;
    public float pushForce;

    public float damage;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();

        Vector3 directionToPlayer = GameManager.instance.player.gameObject.transform.position - transform.position;

        body2D.AddForce(directionToPlayer * pushForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we hit the player
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            GameManager.instance.Respawn();

            //decrease number of asteroids in the level
            GameManager.instance.asteroidsInLevel--;

            //destroy ourself
            Destroy(this.gameObject);
        }
    }
}
