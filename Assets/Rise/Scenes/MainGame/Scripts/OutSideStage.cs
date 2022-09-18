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

    /// <summary>
    /// プレイヤーを倒す一連の処理を実行する
    /// </summary>
    /// <param name="player"></param>
    public override void ExecutePlayerKillManager(Player player)
    {
        var playerKillManager = new PlayerKillManager(this, player);
        playerKillManager.PlayerKill(m_skill);
    }

    /// <summary>
    /// プレイヤーを倒す
    /// </summary>
    /// <param name="player"></param>
    public override void PlayerKill(Player player)
    {
        Destroy(player.gameObject);
    }
}
