using UnityEngine;
using UnityEditor;

public class Patrol_Dog
{
    //[MenuItem("KiCo/Create/Patrol_Dog")]
    public static void CreateAsset()
    {
        //Create();
    }
    //public static void Create()
    //{
    //    ChaseAction chase_action = ScriptableObject.CreateInstance<ChaseAction>();
    //    chase_action.chase_target = "Player";
    //    chase_action.speed = 5;

    //    RoamAction roam_action = ScriptableObject.CreateInstance<RoamAction>();
    //    roam_action.speed = 3;

    //    ScanAction scan_action = ScriptableObject.CreateInstance<ScanAction>();

    //    AssetDatabase.CreateAsset(chase_action, "Assets/Scripts/NPC/_AI/A_Chase.asset");
    //    AssetDatabase.CreateAsset(roam_action, "Assets/Scripts/NPC/_AI/A_Roam.asset");
    //    AssetDatabase.CreateAsset(scan_action, "Assets/Scripts/NPC/_AI/A_Scan.asset");

    //    Duration duration = ScriptableObject.CreateInstance<Duration>();
    //    duration.duration = 5;

    //    LookDecision look = ScriptableObject.CreateInstance<LookDecision>();
    //    look.target = "Player";

    //    AssetDatabase.CreateAsset(duration, "Assets/Scripts/NPC/_AI/D_Duration.asset");
    //    AssetDatabase.CreateAsset(look, "Assets/Scripts/NPC/_AI/D_Look.asset");

    //    BaseState roam = ScriptableObject.CreateInstance<BaseState>();
    //    BaseState scan = ScriptableObject.CreateInstance<BaseState>();
    //    BaseState chase = ScriptableObject.CreateInstance<BaseState>();

    //    AssetDatabase.CreateAsset(scan, "Assets/Scripts/NPC/_AI/S_Scan.asset");
    //    AssetDatabase.CreateAsset(roam, "Assets/Scripts/NPC/_AI/S_Roam.asset");
    //    AssetDatabase.CreateAsset(chase, "Assets/Scripts/NPC/_AI/S_Chase.asset");

    //    scan.actions = new Action[] { scan_action };
    //    scan.transitions = new Transition[] { new Transition(look, chase, 2, null, 0), new Transition(duration, roam, 1, null, 0) };

    //    roam.actions = new Action[] { roam_action };
    //    roam.transitions = new Transition[] { new Transition(look, chase, 2, null, 0), new Transition(duration, scan, 1, null, 0) };

    //    chase.actions = new Action[] { chase_action };
    //    chase.transitions = new Transition[] { new Transition(look, null, 0, scan, 1) };


    //    AssetDatabase.SaveAssets();

    //    EditorUtility.FocusProjectWindow();

    //    Selection.activeObject = chase_action;
    //}
}