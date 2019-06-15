using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownScript : MonoBehaviour
{
    public string Tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals(Tag))
        {
            Destroy(gameObject);
        }
    }
}
