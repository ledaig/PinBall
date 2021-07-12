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
        private bool on_click_right, on_click_left;

        int screenwidth;
        // Use this for initialization
        void Start ()
        {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);
                //Debug.Log("in flipper controler");
                //screeh x中心座標取得
                screenwidth = Screen.width/2;
                on_click_left = on_click_right = false;

        }

        // Update is called once per frame
        void Update ()
        {
          //Vector3 xy[10];
          int touch_count;
          int lc;
          Touch[] l_touch=new Touch[10];
          // screen touch




          touch_count = Input.touchCount;
          //Debug.Log(touch_count);
          if(touch_count > 10){
            //tc = Input.GetTouch(0);
            //Debug.Log(touch_count);
            touch_count = 10;
          }
          l_touch = Input.touches;

          Debug.Log(touch_count);

          if (touch_count > 0){
              for( lc=0 ; lc<touch_count ; lc++ ){
                //Debug.Log(l_touch[lc].position);
                  if( l_touch[lc].phase == TouchPhase.Began && l_touch[lc].position.x < screenwidth){
                    on_click_left = true;
                  }
                  if( l_touch[lc].phase == TouchPhase.Began && l_touch[lc].position.x >= screenwidth){
                    on_click_right = true;
                  }
                  if( l_touch[lc].phase == TouchPhase.Ended && l_touch[lc].position.x < screenwidth){
                    on_click_left = false;
                  }
                  if( l_touch[lc].phase == TouchPhase.Ended && l_touch[lc].position.x >= screenwidth){
                    on_click_right = false;
                  }
              }

              //if ((touch.phase == TouchPhase.Began) && (on_click_left == true ) && tag == "LeftFripperTag") {
              if ( (on_click_left == true ) && tag == "LeftFripperTag") {
                  SetAngle (this.flickAngle);
              }
              //if ((touch.phase == TouchPhase.Began) && (on_click_right == true ) && tag == "RightFripperTag") {
              if ((on_click_right == true )  && tag == "RightFripperTag") {
                  SetAngle (this.flickAngle);
              }
              //if (touch.phase == TouchPhase.Ended) {
              if ( (on_click_left == false ) && tag == "LeftFripperTag") {
                  SetAngle (this.defaultAngle);
              }
              if ( (on_click_right == false ) && tag == "RightFripperTag"){
                  SetAngle (this.defaultAngle);
              }
          }

          // keyboard
                //左矢印キーを押した時左フリッパーを動かす
                if ( (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)) )　&& tag == "LeftFripperTag")
                {
                        SetAngle (this.flickAngle);
                }
                //右矢印キーを押した時右フリッパーを動かす
                if ( (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)) ) && tag == "RightFripperTag")
                {
                        SetAngle (this.flickAngle);

                }
                if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
                {
                      SetAngle (this.flickAngle);

                }

                //矢印キー離された時フリッパーを元に戻す
                if ((Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)) ) && tag == "LeftFripperTag")
                {
                        SetAngle (this.defaultAngle);
                }
                if ((Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)) ) && tag == "RightFripperTag")
                {
                        SetAngle (this.defaultAngle);
                }
                if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
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
