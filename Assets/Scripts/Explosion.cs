using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 爆発
/// </summary>
public class Explosion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
