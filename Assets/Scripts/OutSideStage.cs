using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class OutSideStage : Gimmick
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // プレイヤースクリプトを取得
            var player = collision.GetComponent<Player>();
            if (player != null)
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
