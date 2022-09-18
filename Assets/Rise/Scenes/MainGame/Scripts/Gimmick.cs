using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    [SerializeField, Header("スキル")]
    protected Skill m_skill;

    public abstract void PlayerKill(Player player);
}
