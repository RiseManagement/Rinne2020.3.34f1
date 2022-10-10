﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateSO/CreateSkillEffect/CreateBurnoutResistanceEffect", 
    fileName = "BurnoutResistanceEffect")]
public class BurnoutResistance : SkillEffect
{
    public override void InvokeSkill(Player player)
    {
        // スキルが継承されていれば焼死耐性を有効にする
        if (Skill.IsInherited)
        {
            player.IsBurnoutResistanceEnabled = true;
        }
    }
}
