using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{
    public class ScaleOnY : MonoBehaviour
    {

        public float maxScale = 100f;

        private float originalY = 0;
        private float percentY = 0;

        // Use this for initialization
        void Start()
        {
            originalY = transform.position.y; // recording original Y position as "originalY"
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 scale = transform.localScale; // recording original scale
            Vector3 position = transform.position;

            percentY = position.y / originalY; // turning it into a percentage (e.g. 80 / 100 = 0.8)

            float inversePercentY = 1 - percentY; // inverting percentY (e.g. 1 - 0.2 = 0.8)

            float scaleFactor = maxScale * inversePercentY; // 100 x 0.2 = 20

            scale = Vector3.one * scaleFactor; // (1,1,1) x 20 = (20,20,20)

            transform.localScale = scale; // 
        }
    }
}
