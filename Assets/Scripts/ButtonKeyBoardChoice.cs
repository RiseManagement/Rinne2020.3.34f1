using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyBoardChoice : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    void Start()
    {
        button = GameObject.Find("MenuCanvas/GameStartButton").GetComponent<Button>();
        //ボタンが選択された状態になる
        button.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
