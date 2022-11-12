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
            if (player != null)
            {
                if (player.EnduranceCount == 0)
                {
                    ExecutePlayerKillManager(player);
                }
                else
                {
                    player.EnduranceCount -= 1;
                }
            }
        }
    }

    public override void ExecutePlayerKillManager(Player player)
    {
        var playerKillManager = new PlayerKillManager(player);
        playerKillManager.PlayerKill(this, m_skill);
    }

    public override void PlayerKill(Player player)
    {
        Destroy(player.gameObject);
    }
}
