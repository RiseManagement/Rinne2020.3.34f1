using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ThornFloor : Gimmick
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            if (!player.IsThornDisablementEnabled && player != null)
            {
                ExecutePlayerKillManager(player);
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
