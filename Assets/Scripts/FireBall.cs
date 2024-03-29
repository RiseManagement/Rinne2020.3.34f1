﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Gimmick
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (player != null)
            {
                Debug.Log(player.EnduranceCount);
                if (player.EnduranceCount == 0)
                {
                    ExecutePlayerKillManager(player);
                }
                else
                {
                    player.EnduranceCount -= 1;
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Destroy(gameObject);
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
