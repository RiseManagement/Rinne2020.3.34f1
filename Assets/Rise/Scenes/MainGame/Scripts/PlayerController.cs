using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private JudgeGround m_judgeGround;
    private Rigidbody2D m_rb;
    // 歩きスピード
    private float m_walkSpeed;
    // ダッシュスピード
    private float m_dashSpeed;
    // 立ちサイズ
    private Vector3 m_standingSize;
    // しゃがみサイズ
    private Vector3 m_crouchingSize;
    [SerializeField, Header("ジャンプ力")]
    private float m_jumpPower;

    public enum PlayerDirection
    {
        Stop,
        Right,
        Left,
    }

    PlayerDirection m_playerDirection = PlayerDirection.Stop;

    public void Init()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_judgeGround = GetComponent<JudgeGround>();
        m_standingSize = new Vector3(1f, 1.5f, 1f);
        m_crouchingSize = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput == 0)
        {
            m_playerDirection = PlayerDirection.Stop;
        }
        else if (moveInput > 0)
        {
            m_playerDirection = PlayerDirection.Right;
        }
        else if (moveInput < 0)
        {
            m_playerDirection = PlayerDirection.Left;
        }

        // Shiftキーを押していなければ歩く
        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
        {
            Walk();
        }
        // Shiftキーを押していればダッシュ
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Dash();
        }

        // Sキーまたは↓キーを押していればしゃがむ
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Crouch();
        }
        else
        {
            transform.localScale = m_standingSize;
        }

        // スペースキーを押している、かつ接地状態ならジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && m_judgeGround.IsGround)
        {
            Jump();
        }
    }

    /// <summary>
    /// ダッシュする
    /// </summary>
    private void Dash()
    {
        m_rb.velocity = new Vector2(m_dashSpeed, m_rb.velocity.y);
    }

    /// <summary>
    /// 歩く
    /// </summary>
    private void Walk()
    {
        m_rb.velocity = new Vector2(m_walkSpeed, m_rb.velocity.y);
    }

    /// <summary>
    /// しゃがむ
    /// </summary>
    private void Crouch()
    {
        transform.localScale = m_crouchingSize;
    }

    /// <summary>
    /// ジャンプする
    /// </summary>
    private void Jump()
    {
        m_rb.AddForce(Vector2.up * m_jumpPower);
    }

    private void FixedUpdate()
    {
        switch (m_playerDirection)
        {
            case PlayerDirection.Stop:
                m_walkSpeed = 0;
                m_dashSpeed = 0;
                break;
            case PlayerDirection.Right:
                m_walkSpeed = 6;
                m_dashSpeed = 10;
                break;
            case PlayerDirection.Left:
                m_walkSpeed = -6;
                m_dashSpeed = -10;
                break;
        }
    }
}
