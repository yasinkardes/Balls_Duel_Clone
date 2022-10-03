using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoLayout3D
{
    public class Clone : MonoBehaviour
    {
        public GameObject CloneObject;
        public Transform pos;

        public float collideTime;
        public float mainTime = 3.2f;

        public void Update()
        {
            Destroy(gameObject, 4.3f);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("X2"))
            {
                collideTime = 0;
                collideTime += mainTime;

                for (int i = 0; i <= 1; i++)
                {
                    Instantiate(CloneObject, pos.position, Quaternion.identity, pos);

                    if (collideTime <= mainTime)
                    {
                        CloneObject.GetComponent<Collider>().enabled = false;
                    }

                    else
                    {
                        CloneObject.GetComponent<Collider>().enabled = true;
                    }

                    i++;
                }
            }

            if (other.CompareTag("X3"))
            {
                collideTime = 0;
                for (int i = 0; i <= 2; i++)
                {
                    Instantiate(CloneObject, pos.position, Quaternion.identity, pos);

                    if (collideTime >= mainTime)
                    {
                        CloneObject.GetComponent<Collider>().enabled = true;
                    }

                    else
                    {
                        CloneObject.GetComponent<Collider>().enabled = false;
                    }

                    i++;
                }
            }

            if (other.CompareTag("Push"))
            {
                Destroy(gameObject, 0.02f);
            }
        }
    }
}

