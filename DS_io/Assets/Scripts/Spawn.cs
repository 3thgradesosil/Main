using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //public GameObject Food;
    public string objName;
    public Rigidbody2D foodClone;
    public float Speed;

    void Start()
    {
        InvokeRepeating("Generate", 0, Speed);
    }

    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;
        newObject(objName, Target);
    }
    void newObject(string obj, Vector3 Target)
    {
        foodClone = Instantiate(Resources.Load("Prefabs/"+obj), Target, Quaternion.identity) as Rigidbody2D;
    }
}
