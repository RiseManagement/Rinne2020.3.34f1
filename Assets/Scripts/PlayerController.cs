using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    private Player m_player;
    private Rigidbody2D m_rb;
    [SerializeField, Header("アニメーション")]
    private Animator m_animator;
    [SerializeField, Header("Groundレイヤー")]
    private LayerMask m_groundLayer;
    // 歩きスピード
    private float m_walkSpeed;
    // ダッシュスピード
    private float m_dashSpeed;
    // 立ちサイズ
    private Vector3 m_standingSize;
    // しゃがみサイズ
    private Vector3 m_crouchingSize;

    
    //アニメーションフラグ
    private bool isWalking = false;
    private bool isJumping = false;
    private bool isCrouching = false;
    #endregion

    public enum PlayerDirection
    {
        Stop,
        Right,
        Left,
    }

    PlayerDirection m_playerDirection = PlayerDirection.Stop;

    #region Initialize
    public void Init()
    {
        m_player = GetComponent<Player>();
        m_rb = GetComponent<Rigidbody2D>();
        m_standingSize = new Vector3(1f, 1.5f, 1f);
        m_crouchingSize = new Vector3(1f, 1f, 1f);
        isWalking = false;
        isJumping = false;
        isCrouching = false;
}
    #endregion

    #region UnityCallBack&Input
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
            isCrouching = true;
        }
        else
        {
            transform.localScale = m_standingSize;
            isCrouching = false;
        }

        // スペースキーを押している、かつ接地状態ならジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            Jump();
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        m_animator.SetBool("IsWalk", isWalking);
        m_animator.SetBool("IsJump", isJumping);
        m_animator.SetBool("IsCrouch", isCrouching);
    }

    private void FixedUpdate()
    {
        switch (m_playerDirection)
        {
            case PlayerDirection.Stop:
                m_walkSpeed = 0;
                m_dashSpeed = 0;
                isWalking = false;
                break;
            case PlayerDirection.Right:
                m_walkSpeed = 6;
                m_dashSpeed = 10;
                isWalking = true;
                m_standingSize.x = 1;
                break;
            case PlayerDirection.Left:
                m_walkSpeed = -6;
                m_dashSpeed = -10;
                isWalking = true;
                m_standingSize.x = -1;
                break;
        }
        transform.localScale = m_standingSize;
    }
    #endregion

    #region Movement
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
        m_rb.AddForce(Vector2.up * m_player.JumpPower);
    }
    #endregion

    /// <summary>
    /// 接地状態ならtrueを返す
    /// </summary>
    /// <returns></returns>
    private bool IsGround()
    {
        var leftStartPoint = transform.position - Vector3.right * 0.2f;
        var rightStartPoint = transform.position + Vector3.right * 0.2f;
        var endPoint = transform.position - Vector3.up * 0.1f;
        if (Physics2D.Linecast(leftStartPoint, endPoint, m_groundLayer) ||
            Physics2D.Linecast(rightStartPoint, endPoint, m_groundLayer))
        {
            return true;
        }
        else return false;
    }
}
