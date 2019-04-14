

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {
  public static LevelManager instance;

  private void Awake()
  {
    if (instance != null)
    {
      Debug.LogWarning("Already running instance!");
    }
    else
    {
      instance = this;
    }
  }

  public int kittens_retrieved;
  public bool level_complete;
  public int amountGiven;
  public bool is_dead;
  public bool questIsComplete;
  public GameObject player;
  public GameObject shrine;
  public GameObject quest_cat;
  public GameObject currentObjective;
  public QuestBase objectives;
  private DialogueManager dogNPCDialogue;
  public Text NumberCollectedText;

  void Start() {
    kittens_retrieved = 0;
    amountGiven = 3;
    level_complete = false;
    questIsComplete = false;
    //dogNPCDialogue.GetComponent<Triggers>;
  }

  private void Update() {
    if (player.GetComponent<PlayerController>().is_dead) {
      is_dead = true;
      return;
    }
    if(at_cat() && !objectives.isCompleted) {
      objectives.isActive = true;
      currentObjective.SetActive(true);
    }


    if (objectives.isActive && !objectives.isCompleted) {
      if(amountGiven == 3) {
        objectives.isCompleted = true;
      }
    }
    if(objectives.isCompleted) {
      objectives.isActive = false;
      questIsComplete = true;
      currentObjective.SetActive(false);
    }
    if(check_kitten()) {
      Destroy(GameObject.FindWithTag("mouth").transform.GetChild(0));
      kittens_retrieved++;
      NumberCollectedText.text = "Number collected: " + kittens_retrieved + "/2";
    }
    if(kittens_retrieved == 2) {
      level_complete = true;
    }
  }

  bool check_kitten() {
    return (GameObject.FindWithTag("mouth").transform.childCount > 0 && GameObject.FindWithTag("mouth").transform.GetChild(0).tag == "kitten"
    && at_exit());
  }
  bool at_exit() {
    return Vector3.SqrMagnitude(GameObject.FindWithTag("Player").transform.position - shrine.transform.position) < 50f;
  }
  bool at_cat() {
    return (Input.GetKeyDown(KeyCode.Z) && (Vector3.SqrMagnitude(GameObject.FindWithTag("Player").transform.position - quest_cat.transform.position) < 50f));
  }
}
