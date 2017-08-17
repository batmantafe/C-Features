﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collisions
{
    public class PlayerShip : MonoBehaviour
    {

        //[RequireComponent(typeof(Rigidbody2D))]

        public float acceleration = 50f;
        public float rotationSpeed = 5f;

        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()

        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Accelerate();
            Rotate();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            rigid.AddForce(transform.up * inputV * acceleration);
        }

        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.back, rotationSpeed * inputH);
        }
    }
}
