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
        if (Skill.IsInherited)
        {
            player.IsThornDisablementEnabled = true;
        }
    }
}
