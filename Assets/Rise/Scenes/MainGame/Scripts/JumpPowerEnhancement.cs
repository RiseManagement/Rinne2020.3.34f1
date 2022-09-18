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
            player.JumpPower *= 1.5f;
        }
    }
}
