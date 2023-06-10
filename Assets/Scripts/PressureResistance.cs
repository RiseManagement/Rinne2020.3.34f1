using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillEffect/CreatePressureResistance",
    fileName = "PressureResistance")]
public class PressureResistance : SkillEffect
{
    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていれば圧死耐性スキルを有効にする
        if (Player.m_inheritedSkills.Find(x => x.SkillName == "圧死耐性"))
        {
            player.IsPressureResistanceEnabled = true;
        }
        else
        {
            player.IsPressureResistanceEnabled = false;
        }
    }
}
