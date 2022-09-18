using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerKillManagerから呼ばれて継承を行うクラス
/// </summary>
public class Inheritance
{
    private Skill m_skill;

    public Inheritance(Skill skill)
    {
        m_skill = skill;
    }

    /// <summary>
    /// スキルを継承する
    /// </summary>
    public void InheritSkill()
    {
        m_skill.IsInherited = true;
    }
}
