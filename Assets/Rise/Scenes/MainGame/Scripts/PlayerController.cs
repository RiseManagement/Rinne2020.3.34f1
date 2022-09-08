using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private float m_moveSpeed;

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
        m_rb.velocity = new Vector2(m_moveSpeed, m_rb.velocity.y);
    }

    private void FixedUpdate()
    {
        switch (m_playerDirection)
        {
            case PlayerDirection.Stop:
                m_moveSpeed = 0;
                break;
            case PlayerDirection.Right:
                m_moveSpeed = 6;
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case PlayerDirection.Left:
                transform.localScale = new Vector3(-1f, 1f, 1f);
                m_moveSpeed = -6;
                break;
        }
    }
}
