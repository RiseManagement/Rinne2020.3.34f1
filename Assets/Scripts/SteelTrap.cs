using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // プレイヤースクリプトを取得
            var player = collision.GetComponent<Player>();
            if (player != null)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
