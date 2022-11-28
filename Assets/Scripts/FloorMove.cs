using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    int counter = 0;
    float move = 0.01f;
    [SerializeField] int Maxcounter = 5;

    void Start()
    {
        counter = 0;
        move = 0.01f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 p = new Vector3(move, 0, 0);
        transform.Translate(p);
        counter++;

        if (counter == 60 * Maxcounter)
        {
            counter = 0;
            move *= -1;
        }
    }
}
