using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worm_movement : MonoBehaviour
{
    public Camera ourCamera;
    public float Speed;
    public float offset = 0.5f;
    void Start()
    {
        // if ourCamera is null then set the Main Camera to the variable ourCamera
        if (!ourCamera)
        {
            ourCamera = Camera.main;
        }
    }
    private void Update()
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
    private void FixedUpdate()
    {
        
    }

   
}
