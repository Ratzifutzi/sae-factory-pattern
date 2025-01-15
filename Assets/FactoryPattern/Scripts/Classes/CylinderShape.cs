using FactoryPattern.Scripts.Interfaces;
using UnityEngine;

namespace FactoryPattern.Scripts.Classes
{
    public class CylinderShape : MonoBehaviour, IShape
    {
        public void RotateShape()
        {
            transform.Rotate(60 * Time.deltaTime, 0, 0, Space.Self);
        }

        public void RescaleShape()
        {
            transform.localScale = Vector3.one * 2;
        }
    }
}
