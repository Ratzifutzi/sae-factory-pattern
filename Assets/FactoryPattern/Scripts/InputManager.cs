using System;
using FactoryPattern.Scripts.Interfaces;
using UnityEngine;

namespace FactoryPattern.Scripts
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private ShapeFactory shapeFactory;

        private void Update()
        {
            if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) ) return;
            
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            var spawnPosition = hit.point;
            spawnPosition += new Vector3(0, 2, 0);
            
            IShape instantiatedObject;
            if (Input.GetMouseButtonDown(0))
            {
                instantiatedObject = shapeFactory.CreateShape("Cube", spawnPosition);
            } 
            else if (Input.GetMouseButtonDown(1))
            {
                instantiatedObject = shapeFactory.CreateShape("Cylinder", spawnPosition);
            }
            else
            {
                throw new Exception("IShapeNotImplemented");
            }
            
            // Only happens because both shapes are using IShape interface
            instantiatedObject.RescaleShape();
        }
    }
}
