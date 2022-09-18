using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Header("ジャンプ力")]
    private float m_jumpPower;

    public float JumpPower { get { return m_jumpPower; } set { m_jumpPower = value; } }
    public bool IsThornDisablementEnabled { get; set; }
}
