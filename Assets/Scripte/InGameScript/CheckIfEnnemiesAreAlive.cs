using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfEnnemiesAreAlive : MonoBehaviour
{
    public int listCount = 0;
    private List<GameObject> Children = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Children.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject child in Children)
        {
            if (child == null)
            {
                Children.Remove(child);
            }
        }
        if(Children.Count == 0)
        {
            Debug.Log("CHECKENNEMIALIVE : all ennemies are dead");
            EventManager.TriggerEvent("SwitchLevel", 1);
        }
        listCount = Children.Count;
    }
}
