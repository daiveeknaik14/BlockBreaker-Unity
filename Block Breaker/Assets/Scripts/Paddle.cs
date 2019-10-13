using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float startingYPosition = 0.25f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Start is called before the first frame update
    
    void Start()
    {
        Vector2 startPos = new Vector2(0f, startingYPosition);
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseIn = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX); 
        Vector2 updatePos = new Vector2(mouseIn, startingYPosition);
        transform.position = updatePos;

    }
    
}
