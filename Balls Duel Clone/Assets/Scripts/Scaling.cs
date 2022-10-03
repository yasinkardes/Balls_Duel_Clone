using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoLayout3D
{
    public class Scaling : MonoBehaviour
    {
        public bool isScale = false;
        public GridLayoutGroup3D myGrid;

        private void Start()
        {
            myGrid = GetComponent<GridLayoutGroup3D>();
        }

        private void Update()
        {
            if (isScale == true)
            {
                myGrid.spacing += new Vector3(0.2f, 0, 0) * (Time.deltaTime * 2);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("X2") || other.CompareTag("X3"))
            {
                isScale = true;
            }
        }
    }
}

