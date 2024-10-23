using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
     public TMP_Text uitLevel;  // The UIText_Level Text
     public TMP_Text uitShots;  // The UIText_Shots Text
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
        S = this; // Define the Singleton                                      // c

 level = 0;
 shotsTaken = 0;
 levelMax = castles.Length;
 StartLevel();
    }

    void StartLevel()
    {
         // Get rid of the old castle if one exists
         if (castle != null)
        {
 Destroy(castle);
         }

         // Destroy old projectiles if they exist (the method is not yet written)
 Projectile.DESTROY_PROJECTILES(); // This will be underlined in red  // d

         // Instantiate the new castle
 castle = Instantiate<GameObject>(castles[level]);
 castle.transform.position = castlePos;

         // Reset the goal
 Goal.goalMet = false;

 UpdateGUI();

 mode = GameMode.playing;
        FollowCam.SWITCH_VIEW(FollowCam.eView.both);
     }

    void UpdateGUI()
    {
         // Show the data in the GUITexts
 uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
 uitShots.text = "Shots Taken: " + shotsTaken;
     }

    void Update()
    {
 UpdateGUI();

         // Check for level end
         if ((mode == GameMode.playing) && Goal.goalMet)
        {
             // Change mode to stop checking for level end
 mode = GameMode.levelEnd;
            FollowCam.SWITCH_VIEW(FollowCam.eView.both);

            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);                                           // e
         }
     }

    void NextLevel()
    {                                                         // e
 level++;
         if (level == levelMax)
        {
 level = 0;
 shotsTaken = 0;
         }
 StartLevel();
     }
 
     // Static method that allows code anywhere to increment shotsTaken
     static public void SHOT_FIRED()
    {                                          // f
 S.shotsTaken++;
     }
 
     // Static method that allows code anywhere to get a reference to S.castle
     static public GameObject GET_CASTLE()
    {                                   // g
         return S.castle;
    }
}
