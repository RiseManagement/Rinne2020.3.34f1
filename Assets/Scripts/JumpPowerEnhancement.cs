using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = 
    "CreateSO/CreateSkillEffect/CreateJumpPowerEnhancementEffect", 
    fileName = "JumpPowerEnhancementEffect")]
public class JumpPowerEnhancement : SkillEffect
{
    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていればジャンプ力を1.5倍にする
        if (Player.m_inheritedSkills.Find(x => x.SkillName == "ジャンプ力強化"))
        {
            player.JumpPower *= 1.5f;
        }
        else
        {
            player.JumpPower = 300f;
        }
    }
}
