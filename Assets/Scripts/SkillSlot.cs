using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    private Skill m_skill;
    [SerializeField, Header("スキル名テキスト")]
    private Text m_skillNameText;
    [SerializeField, Header("スキル効果テキスト")]
    private Text m_skillDescriptionText;

    public Skill Skill { get { return m_skill; } set { m_skill = value; } }

    /// <summary>
    /// スキルテキストを表示する
    /// </summary>
    public void ShowSkillText()
    {
        // スキル名を表示(更新)する
        m_skillNameText.text = Skill.SkillName;
        // スキル効果を表示(更新)する
        m_skillDescriptionText.text = Skill.SkillDescription;
    }

    /// <summary>
    /// 継承中のスキルなしの通知を表示する
    /// </summary>
    public void ShowNoSkillAlert()
    {
        m_skillNameText.text = "";
        m_skillDescriptionText.text = "継承中のスキルがありません";
    }
}
