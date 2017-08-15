using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Turret : MonoBehaviour
    {

        public Transform target;

        private Weapon currentWeapon;

        // Use this for initialization
        void Start()
        {
            currentWeapon = GetComponentInChildren<Weapon>(); // get Component from Child, "Weapon" gameobject
            currentWeapon.SetTarget(target);


        }

        
    }
}
