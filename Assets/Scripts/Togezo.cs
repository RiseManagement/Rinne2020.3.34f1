using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togezo : Enemy
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            // トゲ無効スキルが継承されていない、かつplayerがnullでなければ実行
            if (!player.IsThornDisablementEnabled && player != null)
            {
                ExecutePlayerKillManager(player);
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
