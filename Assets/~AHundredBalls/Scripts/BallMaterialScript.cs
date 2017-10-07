using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHundredBalls

{
    public class BallMaterialScript : MonoBehaviour
    {
        public Material[] mats = null;
        public Renderer rend;

        // Use this for initialization
        void Start()
        {
            int randomMatIndex = Random.Range(0, mats.Length);
            rend = GetComponent<Renderer>();
            rend.material = mats[randomMatIndex];
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
