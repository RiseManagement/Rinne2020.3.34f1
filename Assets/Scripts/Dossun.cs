using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dossun : Enemy
{
    private Rigidbody2D rb2D;
    [SerializeField, Header("コライダー")]
    private BoxCollider2D m_coll;
    [SerializeField, Header("トリガーコライダー")]
    private BoxCollider2D m_triggerColl;

    public override void ExecutePlayerKillManager(Player player)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayerKill(Player player)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
