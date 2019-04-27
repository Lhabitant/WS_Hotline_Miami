using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAtttachToPlayer : MonoBehaviour
{
    public float posX = 100;
    public float posY = 100;
    [SerializeField]
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(player.transform.position);  //convert game object position to VievportPoint
        RectTransform rectTransform = GetComponent<RectTransform>();
        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        rectTransform.anchorMin = viewportPoint;
        rectTransform.anchorMax = viewportPoint;
        transform.position = player.transform.position;
    }
}
