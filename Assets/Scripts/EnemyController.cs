﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    #region Variables
    private Rigidbody2D m_rb;
    // 歩きスピード
    public float m_walkSpeed;

    private BoxCollider2D boxCollider;

    private Vector2 velocity;

    private bool grounded;

    [SerializeField, Header("トリガーコライダー")]
    private BoxCollider2D m_triggerColl;

    //通常のサイズ
    private Vector2 defaultSize;
    #endregion

    #region Initialize
    public void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        defaultSize = transform.localScale;
    }
    #endregion

    #region UnityCallBack
    // Update is called once per frame
    void Update ()
    {
        Walk();

        //サイズ更新
        transform.localScale = defaultSize;
    }
    #endregion

    #region Movement
    /// <summary>
    /// 歩く
    /// </summary>
    private void Walk()
    {
        m_rb.velocity = new Vector2(m_walkSpeed, m_rb.velocity.y);
    }
    #endregion


    #region Collsion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" ||
            collision.gameObject.tag == "Player" ||
            collision.gameObject.tag == "Enemy")
        {
            if (transform.localScale.x >= 0 && collision.transform.position.x <= transform.position.x)
            {
                m_walkSpeed *= -1;
                defaultSize.x *= -1;
            }
            else if (transform.localScale.x <= 0 && collision.transform.position.x >= transform.position.x)
            {
                m_walkSpeed *= -1;
                defaultSize.x *= -1;
            }
        }
    }
    #endregion
}
