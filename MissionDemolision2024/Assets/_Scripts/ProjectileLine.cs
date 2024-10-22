using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
 public class ProjectileLine : MonoBehaviour
{
    static List<ProjectileLine> PROJ_LINES = new List<ProjectileLine>();     // a
    private const float DIM_MULT = 0.75f;

    private LineRenderer _line;                                                // a
     private bool _drawing = true;
     private Projectile _projectile;
     
     void Start()
    {
 _line = GetComponent<LineRenderer>();
 _line.positionCount = 1;                                               // b
 _line.SetPosition(0, transform.position);

 _projectile = GetComponentInParent<Projectile>();                      // c

        ADD_LINE(this);
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

    private void OnDestroy()
    {                                                 // c
         // Remove this ProjectileLine from PROJ_LINES
 PROJ_LINES.Remove(this);
     }
 
     static void ADD_LINE(ProjectileLine newLine)
    {
 Color col;                                                            // d
         // Iterate over all the old lines and dim them
         foreach (ProjectileLine pl in PROJ_LINES)
        {
 col = pl._line.startColor;                                        // e
 col = col * DIM_MULT;
 pl._line.startColor = pl._line.endColor = col;                    // f
         }
         // Add newLine to the List
 PROJ_LINES.Add(newLine);                                            // g
     }
}
