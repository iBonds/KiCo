using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Range : MonoBehaviour
{
    public string[] tags;

    private Dictionary<string, bool> tag_to_exist = new Dictionary<string, bool>();
    private Dictionary<string, Vector3> tag_to_pos = new Dictionary<string, Vector3>();

    private void Start()
    {
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
            tag_to_exist[collision_tag] = true;
            tag_to_pos[collision_tag] = other.transform.position;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        string collision_tag = other.gameObject.tag;
        if (tag_to_exist.ContainsKey(collision_tag))
        {
            tag_to_exist[collision_tag] = true;
            tag_to_pos[collision_tag] = other.transform.position;
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

    public bool InRange(string thing)
    {
        bool result = tag_to_exist[thing];
        return result;
    }

    public Vector3 Position(string thing)
    {
        Vector3 result = tag_to_pos[thing];
        Debug.Log("Position of " + thing + ": " + result);
        return result;
    }
}