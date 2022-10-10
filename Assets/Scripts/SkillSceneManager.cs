using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSceneManager : MonoBehaviour
{
    [SerializeField, Header("トゲ無効スキル")]
    private Skill m_thornDisablementSkill;
    [SerializeField, Header("ジャンプ力強化スキル")]
    private Skill m_jumpPowerEnhancementSkill;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"トゲ無効スキルの継承状態がリセットされていないか:{m_thornDisablementSkill.IsInherited}");
        Debug.Log($"ジャンプ力強化スキルの継承状態がリセットされていないか:{m_jumpPowerEnhancementSkill.IsInherited}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneTransManager.TransToStage1();
        }
    }
}
