using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// トゲ床クラス
[RequireComponent(typeof(BoxCollider2D))]
public class ThornFloor : Gimmick
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

    /// <summary>
    /// プレイヤーを倒す一連の処理呼び出し
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
