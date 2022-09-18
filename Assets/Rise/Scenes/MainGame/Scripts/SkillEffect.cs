using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : ScriptableObject
{
    [SerializeField, Header("スキル")]
    private Skill m_skill;

    public Skill Skill => m_skill;

    /// <summary>
    /// スキルを発動する
    /// </summary>
    /// <param name="player"></param>
    public virtual void InvokeSkill(Player player) { }
}
