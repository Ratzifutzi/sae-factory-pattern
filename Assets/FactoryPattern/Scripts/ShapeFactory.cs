using System;
using System.Collections.Generic;
using System.Linq;
using FactoryPattern.Scripts.Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace FactoryPattern.Scripts
{
   public class ShapeFactory: MonoBehaviour
   {
      [SerializeField] private List<GameObject> shapePrefabs = new List<GameObject>();

      private readonly List<IShape> _shapeList = new List<IShape>();

      // ReSharper disable Unity.PerformanceAnalysis
      public IShape CreateShape(string shapeName, Vector3 spawnLocation)
      {
         print(shapeName);
         print(shapePrefabs[0].name);
         
         var shapeObject = shapePrefabs.FirstOrDefault(s => s.name.Equals(shapeName));

         if (!shapeObject) throw new Exception("ShapeNotDefined");

         var instantiatedObject = Instantiate(shapeObject, spawnLocation, quaternion.identity);
         var shape = instantiatedObject.GetComponent<IShape>();
         
         if (shape == null) throw new Exception("ShapeDoesNotImplementIShape");
         
         _shapeList.Add(shape);
         
         return instantiatedObject.GetComponent<IShape>();
      }

      private void Update()
      {
         foreach (var shape in _shapeList)
         {
            shape.RotateShape();
         }
      }
   }
}
