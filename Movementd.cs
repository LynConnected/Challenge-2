using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementd : MonoBehaviour
{
    Vector2 pointA = new Vector2(7, 2);
    Vector2 pointB = new Vector2(7, -3);

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