using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
        //HingeJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start ()
        {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);
                //Debug.Log("in flipper controler");
        }

        // Update is called once per frame
        void Update ()
        {

          // screen touch
          if (Input.touchCount > 0){
              Touch touch = Input.GetTouch(0);

              if (touch.phase == TouchPhase.Began) {
                  SetAngle (this.flickAngle);
              }
              if (touch.phase == TouchPhase.Ended) {
                  SetAngle (this.defaultAngle);
              }
            }

          // keyboard
                //左矢印キーを押した時左フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
                {
                        SetAngle (this.flickAngle);
                }
                //右矢印キーを押した時右フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
                {
                        SetAngle (this.flickAngle);

                }
                if (Input.GetKeyDown(KeyCode.S ))
                {
                      SetAngle (this.flickAngle);

                }

                //矢印キー離された時フリッパーを元に戻す
                if (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
                {
                        SetAngle (this.defaultAngle);
                }
                if (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
                {
                        SetAngle (this.defaultAngle);
                }
                if (Input.GetKeyUp(KeyCode.S) )
                {
                    SetAngle (this.defaultAngle);

                }
        }

        //フリッパーの傾きを設定
        public void SetAngle (float angle)
        {
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }

}
