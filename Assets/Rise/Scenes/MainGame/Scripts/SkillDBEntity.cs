using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillDBEntity", fileName = "SkillDBEntity")]
public class SkillDBEntity : ScriptableObject
{
    // スキルのデータベース
    public List<Skill> m_skills = new List<Skill>();

    public List<Skill> Skills => m_skills;

    /// <summary>
    /// スキルの継承状態をリセットする
    /// インスペクターの継承状態リセットボタンを押すと呼ばれる
    /// </summary>
    public void ResetInherited()
    {
        foreach (var skill in Skills)
        {
            skill.IsInherited = false;
        }
    }
}
