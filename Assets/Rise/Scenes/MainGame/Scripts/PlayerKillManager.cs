using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillManager
{
    private PlayerKill m_playerKill;
    private SkillProvider m_skillProvider;
    private IInheritable m_inheritable;

    public PlayerKillManager(PlayerKill playerKill, SkillProvider skillProvider, IInheritable inheritable)
    {
        m_playerKill = playerKill;
        m_skillProvider = skillProvider;
        m_inheritable = inheritable;
    }

    /// <summary>
    /// プレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeathType"></param>
    public void PlayerKill(GameObject player, CauseOfDeathType causeOfDeathType)
    {
        m_playerKill.Kill(player);
        m_skillProvider.PassSkill(m_inheritable, causeOfDeathType);
    }
}
