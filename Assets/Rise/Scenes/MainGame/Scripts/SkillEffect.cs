using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : ScriptableObject
{
    [SerializeField, Header("スキル")]
    private Skill m_skill;

    public Skill Skill { get { return m_skill; } }

    public virtual void InvokeSkill(Player player) { }
}
