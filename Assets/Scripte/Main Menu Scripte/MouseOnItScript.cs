using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnItScript : MonoBehaviour
{
    public bool mouseOnIt= false;

    private void OnMouseEnter()
    {
        mouseOnIt = true;
    }

    private void OnMouseExit()
    {
        mouseOnIt = false;
    }
}
