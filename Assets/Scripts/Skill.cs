using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathType
{
    落下,
    トゲ床,
    トゲゾー,
    クリボー,
    火の玉,
    火のカーテン,
    カエンバナ,
}

[CreateAssetMenu(menuName = "CreateSO/CreateSkill/CreateSkill", fileName = "Skill")]
public class Skill : ScriptableObject
{
    [SerializeField, Header("ID")]
    private int m_skillID;
    [SerializeField, Header("名前")]
    private string m_skillName;
    [SerializeField, Header("説明")]
    private string m_skillDescription;
    [SerializeField, Header("死因")]
    private DeathType m_deathType;

    public int SkillID { get { return m_skillID; } }
    public string SkillName { get { return m_skillName; } }
    public string SkillDescription { get { return m_skillDescription; } }
    public DeathType DeathType { get { return m_deathType; } }
}
