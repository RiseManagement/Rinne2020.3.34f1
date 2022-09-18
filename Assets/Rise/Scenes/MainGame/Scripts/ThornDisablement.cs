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
        if (Skill.IsInherited)
        {
            // TODO: プレイヤーのトゲ無効フラグを有効にする
        }
    }
}
