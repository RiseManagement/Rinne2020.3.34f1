using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSceneManager : MonoBehaviour
{
    [SerializeField, Header("トゲ無効スキル")]
    private Skill m_thornDisablementSkill;
    [SerializeField, Header("ジャンプ力強化スキル")]
    private Skill m_jumpPowerEnhancementSkill;
    [SerializeField, Header("死因テキスト")]
    private Text m_causeOfDeathText;
    [SerializeField, Header("スキル獲得テキスト")]
    private Text m_skillAcquisitionText;
    [SerializeField, Header("スキル説明")]
    private Text m_skillDescriptionText;
    [SerializeField, Header("残機テキスト")]
    private Text m_remainText;

    // Start is called before the first frame update
    void Start()
    {
        m_causeOfDeathText.text = $"{Inheritance.m_skill.DeathType}によって死亡した";
        m_skillAcquisitionText.text = $"{Inheritance.m_skill.SkillName}を獲得！";
        m_skillDescriptionText.text = Inheritance.m_skill.SkillDescription;
        m_remainText.text = $"残機:{Player.Life}";
    }

    /// <summary>
    /// リトライする
    /// </summary>
    public void OnRetry()
    {
        SceneTransManager.TransToMainGameLatest();
    }

    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void BackToTitle()
    {
        SceneTransManager.TransToTitle();
    }
}
