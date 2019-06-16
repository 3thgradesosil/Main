using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Eat : MonoBehaviour
{
    public string Tag = "Food";
    public Text Letters;
    public float Increase;
    public float tmp;
    private Thread thread = null;
    int Score = 0;
    public Transform bodyObject;
    private Transform head;
    private void OnTriggerEnter2D(Collider2D other)
    {
        head = GameObject.FindGameObjectWithTag("Player").transform.gameObject.transform;
        if (other.gameObject.tag == Tag)
        {
            transform.localScale += new Vector3(Increase, Increase, Increase);
            //tmp = Camera.main.orthographicSize;
            //먹이와 상호작용시 카메라 뷰 축소
            //tmp = Camera.main.orthographicSize;
            Camera.main.orthographicSize += Increase/2;
            Destroy(other.gameObject);

            Score += 10;
            Letters.text = "Score: " + Score;

            if(GetComponent<worm_movement>().bodyParts.Count == 0)
            {
                Vector3 currentPos = head.position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
                GetComponent<worm_movement>().bodyParts.Add(newBodyPart);
            }
            else
            {

                Vector3 currentPos = GetComponent<worm_movement>().bodyParts[GetComponent<worm_movement>().bodyParts.Count -1].position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
                GetComponent<worm_movement>().bodyParts.Add(newBodyPart);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
  
}
