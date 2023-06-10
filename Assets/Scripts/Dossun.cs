using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dossun : Enemy
{
    private Rigidbody2D rb2D;

    public override void ExecutePlayerKillManager(Player player)
    {
        var playerKillManager = new PlayerKillManager(player);
        playerKillManager.PlayerKill(this, m_skill);
    }

    public override void PlayerKill(Player player)
    {
        Destroy(player.gameObject);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();

            // 圧死耐性スキルが継承されていない、かつplayerがnullでなければ実行
            if (!player.IsPressureResistanceEnabled && player != null)
            {
                ExecutePlayerKillManager(player);
            }
        }
    }
}
