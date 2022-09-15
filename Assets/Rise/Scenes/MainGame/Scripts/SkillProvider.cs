using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProvider : MonoBehaviour
{
    [SerializeField, Header("スキルデータベース")]
    private SkillDBEntity m_skillDBEntity;

    /// <summary>
    /// データベースの中から死因が一致するスキルをPlayerのスキル継承メソッドに渡す
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeathType"></param>
    public void PassSkill(IInheritable player, CauseOfDeathType causeOfDeathType)
    {
        var inheritable = player;
        foreach (var skill in m_skillDBEntity.Skills)
        {
            if (skill.CauseOfDeathType == causeOfDeathType)
            {
                inheritable.Inherit(skill);
            }
        }
    }
}
