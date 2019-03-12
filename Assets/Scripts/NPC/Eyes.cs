using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public string[] tags;
    public float fov = 110f;
    public float actual_fov;
    public float angle;
    public float sight_range = 12f;


    private Dictionary<string, bool> tag_to_exist = new Dictionary<string, bool>();
    private Dictionary<string, Vector3> tag_to_pos = new Dictionary<string, Vector3>();




    private void Start()
    {
        actual_fov = fov * 0.5f;
        foreach (string tag in tags)
        {
            tag_to_exist[tag] = false;
            tag_to_pos[tag] = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string collision_tag = other.gameObject.tag;

        if (tag_to_exist.ContainsKey(collision_tag))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, other.transform.position - transform.position, out hit);
            
            if (hit.transform.CompareTag(collision_tag))
            {
                tag_to_exist[collision_tag] = true;
                tag_to_pos[collision_tag] = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        string collision_tag = other.gameObject.tag;
        if (tag_to_exist.ContainsKey(collision_tag))
        {

            //RaycastHit[] hits = Physics.RaycastAll(transform.position, collision.transform.position - transform.position);
            //if (hits.Length > 0)
            //{
            //    foreach (RaycastHit hit in hits)
            //    {
            //        if (hit.transform.CompareTag(collision_tag))
            //        {
            //            tag_to_exist[tag] = true;
            //            tag_to_pos[tag].Set(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            //        }
            //    }
            //}

            tag_to_exist[collision_tag] = false;

            Vector3 direction = other.transform.position - transform.position;
            angle = Vector3.Angle(direction, transform.forward);

            if(angle < actual_fov)
            {
                RaycastHit hit;
                
                Debug.DrawRay(transform.position, (other.transform.position - transform.position));
                if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity)  && hit.transform.CompareTag(collision_tag))
                {
                    //Debug.Log("hit");
                    tag_to_exist[collision_tag] = true;
                    tag_to_pos[collision_tag] = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
                }
            }
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        string collision_tag = other.gameObject.tag;
        if (tag_to_exist.ContainsKey(collision_tag))
        {
            tag_to_exist[collision_tag] = false;
        }
    }

    public bool sees(string thing)
    {
        if (tag_to_exist.ContainsKey(thing))
            return tag_to_exist[thing];
        else
        {
            tag_to_exist[thing] = false;
            tag_to_pos[thing] = Vector3.zero;
            return false;
        }
    }

    public Vector3 position(string thing)
    {
        Vector3 result;
        if (tag_to_pos.TryGetValue(thing, out result))
            return result;
        else
            return Vector3.zero;
    }
}
