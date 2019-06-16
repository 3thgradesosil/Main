using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueFire : MonoBehaviour
{
    private const float moveSpeed = 15;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);
        if(transform.position.x==dir.x && transform.position.y == dir.y)
        {
            Destroy(gameObject);
        }
    }
}
