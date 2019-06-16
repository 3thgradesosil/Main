using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class QueueMove : MonoBehaviour
{
    //About Movement
    public Camera ourCamera;
    public float Speed;
    public float offset = 0.5f;
    //About Fire
    public GameObject QueueFire;
    public bool canShoot = true;
    public bool moveAble = true;
    const float shootDelay = 3.0f;
    float shootTimer = 0;
    void Start()
    {
        // if ourCamera is null then set the Main Camera to the variable ourCamera
        if (!ourCamera)
        {
            ourCamera = Camera.main;
        }
    }
    void Update()
    {
        if (moveAble)
        {
            Vector3 Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime / transform.localScale.x);
            //I have to fixed direction that looking
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
        }
        if (shootTimer > shootDelay && Input.GetMouseButtonDown(0))
        {
            Instantiate(QueueFire, transform.position, transform.rotation);
            shootTimer = 0;
            moveAble = false;
        }
        shootTimer += Time.deltaTime;
        if(moveAble==false)
           //transform.position = Vector2.MoveTowards(transform.position, dir, Speed * Time.deltaTime);
        if (shootTimer > shootDelay)
            moveAble = true;
    }
}
