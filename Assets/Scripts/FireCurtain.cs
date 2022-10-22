using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCurtain : Gimmick
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            // playerがnullじゃない、かつ焼死耐性スキルが継承されていなければ実行
            if (player != null && !player.IsBurnoutResistanceEnabled)
            {
                ExecutePlayerKillManager(player);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            // playerがnullじゃない、かつ焼死耐性スキルが継承されていれば実行
            if (player != null && player.IsBurnoutResistanceEnabled)
            {
                // プレイヤーが火に耐えられる時間を減らす
                player.FireCount -= 1f * Time.deltaTime;

                if (player.FireCount <= 0f)
                {
                    ExecutePlayerKillManager(player);
                }
            }
        }
    }

    public override void ExecutePlayerKillManager(Player player)
    {
        var playerKillManager = new PlayerKillManager(this, player);
        playerKillManager.PlayerKill(m_skill);
    }

    public override void PlayerKill(Player player)
    {
        Destroy(player.gameObject);
    }
}
