using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Range : MonoBehaviour
{
    public HashSet<string> tags_to_check = new HashSet<string>();

    private Dictionary<string, bool> tag_to_exist = new Dictionary<string, bool>();
    private Dictionary<string, Vector3> tag_to_pos = new Dictionary<string, Vector3>();

    private void Start()
    {
        foreach (string tag in tags_to_check)
        {
            tag_to_exist[tag] = false;
            tag_to_pos[tag] = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collision_tag = collision.gameObject.tag;

        if (tags_to_check.Contains(collision_tag))
        {
            tag_to_exist[collision_tag] = true;
            tag_to_pos[collision_tag].Set(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        string collision_tag = collision.gameObject.tag;
        if (tags_to_check.Contains(collision_tag))
        {
            tag_to_exist[collision_tag] = true;
            tag_to_pos[collision_tag].Set(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        string collision_tag = collision.gameObject.tag;
        if (tags_to_check.Contains(collision_tag))
        {
            tag_to_exist[collision_tag] = false;
        }
    }

    public bool InRange(string thing)
    {
        bool result;
        tag_to_exist.TryGetValue(thing, out result);
        return result;
    }

    public Vector3 Position(string thing)
    {
        Vector3 result;
        if (tag_to_pos.TryGetValue(thing, out result))
            return result;
        else
            return Vector3.zero;
    }
}