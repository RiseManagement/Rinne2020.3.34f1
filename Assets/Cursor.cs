using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    //ボタンのオブジェクト
    public GameObject buttonObj;
    RectTransform rectTransform = null;

    //ボタン数
    public int buttonNum;

    //現在のボタンの位置
    public int buttonSelect;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = buttonObj.GetComponent<RectTransform>();
        buttonNum = GameObject.FindGameObjectsWithTag("Button").Length;
    }

    // Update is called once per frame
    void Update()
    {
        CursorMove();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectStageButton();
        }
    }

    //移動処理
    void CursorMove()
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && buttonSelect < buttonNum)
        {//右
            this.gameObject.transform.position =
                new Vector2(this.gameObject.transform.position.x + rectTransform.rect.width,
                            this.gameObject.transform.position.y);
            buttonSelect++;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && buttonSelect > 1)
        {//左
            this.gameObject.transform.position =
                new Vector2(this.gameObject.transform.position.x - rectTransform.rect.width,
                    this.gameObject.transform.position.y);
            buttonSelect--;
        }
    }

    //決定後の遷移
    void SelectStageButton()
    {
        SceneTransManager.TransToStage(buttonSelect);
    }
}
