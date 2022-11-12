using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillEffect/CreateBurnoutResistanceEffect", 
    fileName = "BurnoutResistanceEffect")]
public class BurnoutResistance : SkillEffect
{
    [SerializeField, Header("火に耐えられる回数(通常時)")]
    private int m_normalEnduranceCount;
    [SerializeField, Header("火に耐えられる回数(焼死耐性時)")]
    private int m_enduranceCountAtResistance;

    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていれば火に耐えられる回数を5にする
        if (Player.m_inheritedSkills.Find(x => x.SkillName == "焼死耐性"))
        {
            player.EnduranceCount = m_enduranceCountAtResistance;
        }
        else
        {
            player.EnduranceCount = m_normalEnduranceCount;
        }
    }
}
