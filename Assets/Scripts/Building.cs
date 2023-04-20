using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public List<GameObject> peons = new List<GameObject>();

    public void AddPeon(GameObject peon)
    {
        peons.Add(peon);
    }

    public void RemovePeon(GameObject peon)
    {
        peons.Remove(peon);
    }
}