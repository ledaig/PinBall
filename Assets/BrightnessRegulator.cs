using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour
{
        // Materialを入れる
        Material myMaterial;

        // Emissionの最小値
        private float minEmission = 0.3f;
        // Emissionの強度
        private float magEmission = 2.0f;
        // 角度
        private int degree = 0;
        //発光速度
        private int speed = 10;
        // ターゲットのデフォルトの色
        Color defaultColor = Color.white;
        // score
        private GameObject scoreText;
        public Score scoreScript;

        //--
        private int l_star=20;
        private int l_cloud=100;
        private int s_star=10;
        private int s_cloud=30;



        // Use this for initialization
        void Start ()
        {

                // タグによって光らせる色を変える
                if (tag == "SmallStarTag")
                {
                        this.defaultColor = Color.white;
                }
                else if (tag == "LargeStarTag")
                {
                        this.defaultColor = Color.yellow;
                }
                else if(tag == "SmallCloudTag" || tag == "LargeCloudTag")
                {
                        this.defaultColor = Color.cyan;
                }

                //オブジェクトにアタッチしているMaterialを取得
                this.myMaterial = GetComponent<Renderer> ().material;

                //オブジェクトの最初の色を設定
                myMaterial.SetColor ("_EmissionColor", this.defaultColor*minEmission);

                //score object
                scoreText = GameObject.Find("ScoreText");
                scoreScript = scoreText.GetComponent<Score>();
        }

        // Update is called once per frame
        void Update ()
        {

                if (this.degree >= 0)
                {
                        // 光らせる強度を計算する
                        Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

                        // エミッションに色を設定する
                        myMaterial.SetColor ("_EmissionColor", emissionColor);

                        //現在の角度を小さくする
                        this.degree -= this.speed;
                }
                //draw score
                //Debug.Log(this.scoreScript.score);


        }

        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other)
        {
                //ini l_score = script
                //角度を180に設定
                this.degree = 180;
                //this.prev_score = this.socre;
                if (tag == "SmallStarTag")
                {
                      scoreScript.score += s_star;
                }
                else if (tag == "LargeStarTag")
                {
                      scoreScript.score += l_star;
                }
                else if(tag == "SmallCloudTag" )
                {
                        scoreScript.score += s_cloud;
                        //Debug.Log("sc hit");
                }
                else if(tag == "LargeCloudTag" )
                {
                      scoreScript.score += l_cloud;
                        //Debug.Log("lc hit");
                }


        }
}
