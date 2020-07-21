using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;     //moving forward and back speed
    public float rotateSpeed;   //speed that we rotate left and right

    [Header("Shooting")]
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float shootDelay;
    private float timer;
    private bool canShoot;

    private void Update()
    {
        if(timer <= 0)
        {
            canShoot = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        // WASD && Arrow Keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Move the player forward and backward
        Vector3 myPos = transform.position;
        myPos += transform.up * vertical * moveSpeed * Time.deltaTime;
        transform.position = myPos;

        //rotate in the direction press by the player
        transform.Rotate(transform.forward * -horizontal * rotateSpeed * Time.deltaTime);

        //check if player pressed the shoot button
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canShoot)
            {
                //shoot our bullet
                Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
                canShoot = false;
                timer = shootDelay;
            }
        }
    }
}
