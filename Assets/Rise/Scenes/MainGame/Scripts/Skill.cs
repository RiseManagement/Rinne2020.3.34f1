using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkill/CreateSkill", fileName = "Skill")]
public class Skill : ScriptableObject
{
    [SerializeField, Header("ID")]
    private int m_skillID;
    [SerializeField, Header("名前")]
    private string m_skillName;
    [SerializeField, Header("説明")]
    private string m_skillDescription;
    [SerializeField, Header("スキルを継承しているか")]
    private bool m_isInherited;

    public int SkillID { get { return m_skillID; } }
    public string SkillName { get { return m_skillName; } }
    public string SkillDescription { get { return m_skillDescription; } }
    public bool IsInherited { get { return m_isInherited; } set { m_isInherited = value; } }
}
