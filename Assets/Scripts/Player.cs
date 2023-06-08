using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    private float m_jumpPower;
    // 火に耐えられる回数
    private int m_enduransCount;
    // 残機
    private static int m_life = 5;
    // 継承中のスキル
    public static List<Skill> m_inheritedSkills = new List<Skill>();
    // 入れ替えスキル
    public static List<Skill> m_swapSkills = new List<Skill>();
    // スキル継承上限
    private static int m_inheritanceLimit = 3;
    [SerializeField, Header("チュートリアルキャラソケット")]
    private GameObject m_spCharaSocket;

    public float JumpPower { get { return m_jumpPower; } set { m_jumpPower = value; } }
    // トゲ無効スキルが有効かどうか
    public bool IsThornDisablementEnabled { get; set; }
    // 火に耐えられる回数
    public int EnduranceCount { get { return m_enduransCount; } set { m_enduransCount = value; } }
    public bool IsDefeatTheKuriboEnabled { get; set; }
    // 残機
    public static int Life { get { return m_life; } set { m_life = value; } }
    // スキル継承上限
    public static int InheritanceLimit { get { return m_inheritanceLimit; } }
    public GameObject m_spChara;
    public GameObject SpCharaSocket { get { return m_spCharaSocket; } }
}
