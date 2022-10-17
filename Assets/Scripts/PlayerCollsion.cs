using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name + "と判定した");
            //ここからプレイヤーに起きることを記述
        }
    }
}
