using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillDBEntity", fileName = "SkillDBEntity")]
public class SkillDBEntity : ScriptableObject
{
    // スキルのデータベース
    public List<Skill> m_skills = new List<Skill>();
}
