using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Eat : MonoBehaviour
{
    public string Tag;
    public Text Letters;
    public float Increase;
    public float tmp;
    private Thread thread = null;
    int Score = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
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
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
  
}
