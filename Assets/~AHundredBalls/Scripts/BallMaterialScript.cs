﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHundredBalls

{
    public class BallMaterialScript : MonoBehaviour
    {
        public Material[] mats = null;
        public Renderer rend;
        public TrailRenderer trail;

        private int count;

        // Use this for initialization
        void Start()
        {
            RandomMat();

            RandomTrail();

            count = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void RandomMat()
        {
            int randomMatIndex = Random.Range(0, mats.Length);
            rend = GetComponent<Renderer>();
            rend.material = mats[randomMatIndex];
        }

        void RandomTrail()
        {
            int randomMatIndex = Random.Range(0, mats.Length);
            trail = gameObject.GetComponent<TrailRenderer>();
            trail.material = mats[randomMatIndex];

            int randomNumber = Random.Range(0, 4); // min Incl, max Excl

            if (randomNumber == 3)
            {
                trail.enabled = true;
            }

            if (randomNumber <= 2)
            {
                trail.enabled = false;
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("HundredBucket"))
            {
                trail.enabled = false;

                ManageScoreScript.startPerc = true;
                
            }

            if(other.gameObject.CompareTag("HundredDestroyer"))
            {
                Destroy(gameObject);

                count = 1;

                ManageScoreScript.missedCount = ManageScoreScript.missedCount + count;

                count = 0;
            }
        }
    }    
}
