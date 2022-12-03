using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakudanBana : MonoBehaviour
{
    [SerializeField, Header("爆発オブジェクト")]
    private GameObject m_explosionObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("Explode", 1f);
        }
    }

    /// <summary>
    /// 爆発する
    /// </summary>
    private void Explode()
    {
        Instantiate(m_explosionObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
