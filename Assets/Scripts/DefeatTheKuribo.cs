using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillEffect/CreateDefeatTheKuriboEffect", 
    fileName = "DefeatTheKuribo")]
public class DefeatTheKuribo : SkillEffect
{
    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていればジャンプ力を1.5倍にする
        if (Skill.IsInherited)
        {
            player.IsDefeatTheKuriboEnabled = true;
        }
    }
}
