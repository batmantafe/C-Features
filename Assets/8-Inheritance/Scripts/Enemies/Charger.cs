using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance // match namespace to where you're inheriting for it to work
{

    public class Charger : Enemy // change MonoBehaviour to inherit
    {
        [Header("Charger")]
        public float chargeForce = 5f;
        public float knockback = 4.5f;

    }
}
