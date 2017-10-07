using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AHundredBalls
{
    public class ManageScoreScript : MonoBehaviour
    {
        public Text countText;
        public static int scoreCount;

        public Text missedText;
        public static int missedCount;

        public Text percentageText;
        public float perCalFloat;
        public float perCalInt;

        public static bool startPerc;

        // Use this for initialization
        void Start()
        {
            startPerc = false;
        }

        // Update is called once per frame
        void Update()
        {
            SetCountText();
            SetMissedCount();
            SetPercentage();
        }

        void SetCountText()
        {
            countText.text = "Balls in Buckets: " + scoreCount.ToString();
        }

        void SetMissedCount()
        {
            missedText.text = "Lost Balls: " + missedCount.ToString();
        }

        void SetPercentage()
        {
            if (startPerc == true)
            {
                perCalFloat = (missedCount / (scoreCount + missedCount));
                perCalInt = (perCalFloat * 100);

                percentageText.text = "Ball In %: " + perCalFloat.ToString();
            }
        }
    }
}
