using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBtn : MonoBehaviour
{
    public GameObject ButtonPrefab;　//ボタンプレハブを定義
    public int stageNum = 3;    //ステージ数
    public GameObject reproductionObj;　//複製保持用オブジェクト

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas"); //Canvasを探して、canvasとして定義
        GameObject instance = null;
        RectTransform rectTransform = null;

        for (int i = 1; i < stageNum; i++)
        {
            //ボタン複製
            if (instance == null) {
                instance = Instantiate(ButtonPrefab); //ボタンプレハブ複製
            }
            else {
                instance = Instantiate(reproductionObj);
            }
            rectTransform = instance.GetComponent<RectTransform>();

            //データ設定
            instance.gameObject.transform.localPosition =
                new Vector2(instance.transform.localPosition.x + rectTransform.rect.width,
                instance.transform.localPosition.y);
            instance.name = "Btn_Stage" + (i + 1).ToString();
            instance.transform.SetParent(canvas.transform, false);
            reproductionObj = instance;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
