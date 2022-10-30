using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerKillManagerから呼ばれて継承を行うクラス
/// </summary>
public class Inheritance
{
    public static Skill m_skill;
    public static Player m_player;

    public Inheritance(Skill skill)
    {
        m_skill = skill;
    }

    /// <summary>
    /// スキルを継承する
    /// </summary>
    public void InheritSkill()
    {
        Player.m_inheritedSkills.Add(m_skill);
    }
}
