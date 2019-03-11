using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementb : MonoBehaviour
{
    Vector2 pointA = new Vector2(-4, 1);
    Vector2 pointB = new Vector2(-4, 3);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}