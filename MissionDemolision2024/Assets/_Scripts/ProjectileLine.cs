using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
 public class ProjectileLine : MonoBehaviour
{
     private LineRenderer _line;                                                // a
     private bool _drawing = true;
     private Projectile _projectile;
     
     void Start()
    {
 _line = GetComponent<LineRenderer>();
 _line.positionCount = 1;                                               // b
 _line.SetPosition(0, transform.position);

 _projectile = GetComponentInParent<Projectile>();                      // c
    }
 
     void FixedUpdate()
    {
         if (_drawing)
        {
 _line.positionCount++;                                            // d
 _line.SetPosition(_line.positionCount - 1, transform.position);
             // If the Projectile Rigidbody is sleeping, stop drawing
             if (_projectile != null)
            {                                      // e
                 if (!_projectile.awake)
                {
 _drawing = false;
 _projectile = null;
                 }
             }
        }
    }
}
