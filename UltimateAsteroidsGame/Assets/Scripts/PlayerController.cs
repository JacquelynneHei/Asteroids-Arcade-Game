using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //-1, go left --- 1, go right
        float vertical = Input.GetAxis("Vertical"); // -1, go down --- 1, go up

        Vector3 myPos = transform.position;
        myPos += transform.up * vertical * speed * Time.deltaTime;
        transform.position = myPos;

        transform.Rotate(transform.forward * horizontal * rotateSpeed * Time.deltaTime * -1);
    }
}
