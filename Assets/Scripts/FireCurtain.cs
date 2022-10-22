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

            if (player != null && player.IsBurnoutResistanceEnabled)
            {
                player.FireCount -= 1f * Time.deltaTime;
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
