using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IInheritable
{
    // 継承中のスキル
    public static List<Skill> m_inheritedSkills = new List<Skill>();

    /// <summary>
    /// スキルを継承する
    /// </summary>
    /// <param name="skill"></param>
    public void Inherit(Skill skill)
    {
        throw new System.NotImplementedException();
    }
}
