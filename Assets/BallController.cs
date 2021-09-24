using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //点数を表示するテキスト
    private GameObject score;

    //点数を格納する変数
    static int currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreオブジェクトを取得
        this.score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //点数を表示する
        ShowScore();

    }

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision other)
    {
        //タグを識別してそれぞれの点数を加算する
        if(other.gameObject.tag == "SmallStarTag")
        {
            currentScore += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            currentScore += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            currentScore += 15;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            currentScore += 30;
        }
        
    }

    //点数を表示する関数
    private void ShowScore()
    {
        // 数値を文字列に変換
        string s = currentScore.ToString();
        //Scoreに点数を表示
        this.score.GetComponent<Text>().text = s;
    }
}
