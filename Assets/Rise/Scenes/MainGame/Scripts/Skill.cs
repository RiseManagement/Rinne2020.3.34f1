using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    [SerializeField, Header("ID")]
    private int m_skillID;
    [SerializeField, Header("名前")]
    private string m_skillName;
    [SerializeField, Header("説明")]
    private string m_skillDescription;
    [SerializeField, Header("スキルを継承しているか")]
    private bool m_isExtendedSkill;
    [SerializeField, Header("死因")]
    private CauseOfDeathType m_causeOfDeathType;

    public int SkillID { get { return m_skillID; } }
    public string SkillName { get { return m_skillName; } }
    public string SkillDescription { get { return m_skillDescription; } }
    public bool IsExtendedSkill { get { return m_isExtendedSkill; } set { m_isExtendedSkill = value; } }
    public CauseOfDeathType CauseOfDeathType { get { return m_causeOfDeathType; } }
}
