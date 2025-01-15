using FactoryPattern.Scripts.Interfaces;
using UnityEngine;

namespace FactoryPattern.Scripts.Classes
{
    public class CubeShape : MonoBehaviour, IShape
    {
        public void RotateShape()
        {
            transform.Rotate(0, 60 * Time.deltaTime, 0, Space.Self);
        }

        public void RescaleShape()
        {
            transform.localScale = Vector3.one * 2;
        }
    }
}
