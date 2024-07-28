using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;
    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //以下ボール得点計算用
    private int AllPoints = 0;
    private GameObject pointsText;
    //ボール得点計算用ここまで

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        gameoverText = GameObject.Find("GameOverText");

        //以下ボール得点計算用
        pointsText = GameObject.Find("Points");
        //ボール得点計算用ここまで
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //以下ボール得点計算用
        this.pointsText.GetComponent<Text>().text = "Points:" + this.AllPoints;
        //ボール得点計算用ここまで
        
    }

    //以下ボール得点計算用
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag== "SmallStarTag")
        {
            this.AllPoints += 5;
        }
        else if(other.gameObject.tag== "LargeStarTag")
        {
            this.AllPoints += 10;
        }
        else if(other.gameObject.tag== "SmallCloudTag")
        {
            this.AllPoints += 12;
        }
        else if(other.gameObject.tag== "LargeCloudTag")
        {
            this.AllPoints += 15;
        }
    }
    //ボール得点計算用ここまで
}
