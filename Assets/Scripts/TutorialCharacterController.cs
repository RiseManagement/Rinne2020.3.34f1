using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    [SerializeField, Header("Player")]
    private GameObject m_playerObj;

    [SerializeField, Header("TutorialController")]
    private TutorialController m_tutorialController;

    private void Start()
    {

    }

    private void Update()
    {

    }

    /// <summary>
    /// 当たり判定（当たっている最中）
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        m_tutorialController.TutorialExplanationActive();
    }

    /// <summary>
    /// 当たり判定（離れたら）
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_tutorialController.TutorialExplanationNotActive();
    }
}
