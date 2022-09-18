using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillManager
{
    //ギミック
    private Gimmick m_gimmick;
    // プレイヤー
    private Player m_player;

    public PlayerKillManager(Gimmick gimmick, Player player)
    {
        m_gimmick = gimmick;
        m_player = player;
    }

    /// <summary>
    /// プレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeathType"></param>
    public void PlayerKill(Skill skill)
    {
        var inheritance = new Inheritance(skill);
        inheritance.InheritSkill();
        m_gimmick.PlayerKill(m_player);
    }
}
