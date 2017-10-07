using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHundredBalls

{
    public class BallMaterialScript : MonoBehaviour
    {
        public Material[] mats = null;
        public Renderer rend;
        public TrailRenderer trail;

        // Use this for initialization
        void Start()
        {
            RandomMat();

            RandomTrail();
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
            trail = gameObject.GetComponent<TrailRenderer>();

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
    }
}
