using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoLayout3D
{
    public class Shoot : MonoBehaviour
    {
        public Rigidbody Ball;

        //FixedUpdate ile test et
        public void Update()
        {
            if (Input.GetMouseButtonDown(0) && gameObject.transform.parent.name == "PlayerShoot")
            {
                Rigidbody clone;

                clone = Instantiate(Ball, transform.position, transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            }
        }
    }
}
