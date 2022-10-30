using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    private float m_jumpPower;
    [SerializeField, Header("炎に耐えられる時間")]
    private float m_FireCount;
    // 残機
    private static int m_remain = 3;
    // 継承中のスキル
    public static List<Skill> m_inheritedSkills = new List<Skill>();

    public float JumpPower { get { return m_jumpPower; } set { m_jumpPower = value; } }
    // トゲ無効スキルが有効かどうか
    public bool IsThornDisablementEnabled { get; set; }
    // 焼死耐性スキルが有効かどうか
    public bool IsBurnoutResistanceEnabled { get; set; }
    public float FireCount { get { return m_FireCount; } set { m_FireCount = value; } }
    public bool IsDefeatTheKuriboEnabled { get; set; }
    // 残機
    public static int Remain { get { return m_remain; } set { m_remain = value; } }
}
