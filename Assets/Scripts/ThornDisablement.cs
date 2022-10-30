using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = 
    "CreateSO/CreateSkillEffect/CreateThornDisablementEffect", 
    fileName = "ThornDisablementEffect")]
public class ThornDisablement : SkillEffect
{
    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていればトゲ無効スキルを有効にする
        if (Player.m_inheritedSkills.Find(x => x.SkillName == "トゲ無効"))
        {
            player.IsThornDisablementEnabled = true;
        }
        else
        {
            player.IsThornDisablementEnabled = false;
        }
    }
}
