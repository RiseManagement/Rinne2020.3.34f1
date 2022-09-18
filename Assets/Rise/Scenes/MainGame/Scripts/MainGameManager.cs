using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")]
    private Player m_player;
    [SerializeField, Header("PlayerController")]
    private PlayerController m_playerController;
    [SerializeField, Header("スキル効果")]
    private List<SkillEffect> m_skillEffects = new List<SkillEffect>();

    // Start is called before the first frame update
    void Start()
    {
        m_playerController.Init();
        foreach (var skillEffect in m_skillEffects)
        {
            skillEffect.InvokeSkill(m_player);
        }
    }
}
