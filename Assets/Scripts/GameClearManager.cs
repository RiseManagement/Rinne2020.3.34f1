using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void BackToTitle()
    {
        SceneTransManager.TransToTitle();
    }
}
