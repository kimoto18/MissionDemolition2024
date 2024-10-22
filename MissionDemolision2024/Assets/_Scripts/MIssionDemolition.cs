using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;                                                             // a

 public enum GameMode
{                                                            // b
     idle, 
     playing,
     levelEnd
 }

public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S; // a private Singleton                    // c
 
     [Header("Inscribed")]
     public Text uitLevel;  // The UIText_Level Text
     public Text uitShots;  // The UIText_Shots Text
     public Vector3 castlePos; // The place to put castles
    public GameObject[] castles;   // An array of the castles
 
     [Header("Dynamic")]
    public int level;     // The current level
     public int levelMax;  // The number of levels
     public int shotsTaken;
    public GameObject castle;    // The current castle
     public GameMode mode = GameMode.idle;
     public string showing = "Show Slingshot"; // FollowCam mode
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
