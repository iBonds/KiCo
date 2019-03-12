using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
  public float runningMultipler = 15;
  public float jumpHeight = 1f;
  public bool toJump;
  public bool isRunning;
  public Controller kitten;
  private Vector3 dirVector;
  public int health = 3;
  public float timeLastHit = 0f;

  private Vector3 local_scale;
  private Rigidbody rb;
  private BoxCollider boxCollider;
  private float distanceToGround;
  private const float gravity = 9.8f;
  public FlashCanvas cv;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    boxCollider = GetComponent<BoxCollider>();
    distanceToGround = GetComponent<Collider>().bounds.extents.y;
    local_scale = transform.localScale;
        kitten = GameObject.FindGameObjectWithTag("kitten").GetComponent<Controller>();
  }

  bool IsGrounded()
  {
    return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
  }

  void FixedUpdate()
  {
    //dirVector = new Vector3(-1 * Input.GetAxis("Horizontal"), 0, -1 * Input.GetAxis("Vertical")).normalized;
    dirVector = Input.GetAxis("Vertical") * (transform.rotation * Vector3.forward); // Why doesn't dirVector*= transform.rotation work?

    rb.MovePosition(transform.position + dirVector * Time.deltaTime * (isRunning ? runningMultipler : 10));

        Vector3 rotVector = new Vector3(0, Input.GetAxis("Horizontal"), 0);
    if(rotVector != Vector3.zero)
        transform.Rotate(rotVector);

    if (toJump && kitten.is_picked_up == false)
    {
      rb.AddForce(transform.up * Mathf.Sqrt(2f * jumpHeight * gravity), ForceMode.VelocityChange);
      toJump = false;
    }
  }

  void Update()
  {
    if(health <= 0) {
      onDeath();
    }
    toJump = (Input.GetKeyDown("space") && IsGrounded()) || toJump;
    isRunning = Input.GetKey(KeyCode.LeftShift);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Dog"))
    doDamage();
  }
  void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Dog"))
    doDamage();
  }

  public void doDamage() {
    if (Time.fixedTime - timeLastHit > 5f || timeLastHit == 0)
    {
      cv.playerDamaged();
      health--;
      timeLastHit = Time.fixedTime;
    }
  }

  public void onDeath() {
    cv.playerDamaged();
    Application.LoadLevel("Start Menu");
  }
}
