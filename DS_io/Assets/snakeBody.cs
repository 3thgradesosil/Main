using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBody : MonoBehaviour
{

    private int myOrder;
    private Transform head;

    // Start is called before the first frame update
    void Start()    //몸체 각각이 머리를 따라가도록 조정
    {
        head = GameObject.FindGameObjectWithTag("Player").transform.gameObject.transform;
        for(int i=0; i< head.GetComponent<worm_movement>().bodyParts.Count; i++)
        {
            if(gameObject == head.GetComponent<worm_movement>().bodyParts[i].gameObject)
            {
                print("Wow");
                myOrder = i;
            }
        }
    }
    private Vector3 movementVelocity;
    [Range(0.0f,1.0f)]
    public float overTime = 0.05f;

    // Update is called once per frame
    private void Update()      //몸체들의 방향을 머리랑 맞춤
    {
        if(myOrder == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.LookAt(head.transform.position);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<worm_movement>().bodyParts[myOrder - 1].position, ref movementVelocity, overTime);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.LookAt(head.transform.position);
        }
    }
}
