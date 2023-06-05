using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ここからプレイヤーに起きることを記述
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (transform.parent == null && col.gameObject.name == "MoveFloor")
        {
            var emptyObject = new GameObject();
            emptyObject.transform.parent = col.gameObject.transform;
            transform.parent = emptyObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (transform.parent != null && col.gameObject.name == "MoveFloor")
        {
            transform.parent = null;
        }
    }
}
