using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    [SerializeField, Header("遷移先のステージ番号")]
    private int m_nextStageNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneTransManager.TransToStage(m_nextStageNumber);
        }
    }
}
