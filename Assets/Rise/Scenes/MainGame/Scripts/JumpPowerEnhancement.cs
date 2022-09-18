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
        if (Skill.IsInherited)
        {
            // TODO: プレイヤーのジャンプ力を1.5倍にする            
        }
    }
}
