using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public   int score=0;
    public   int prev_score=0;

    private GameObject scoreText;
    private Text drawText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {


        drawText = this.scoreText.GetComponent<Text>();

        drawText.text = this.score.ToString();

    }
}
