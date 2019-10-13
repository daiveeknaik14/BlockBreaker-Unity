using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    SceneLoader scene;

    private void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
    }
    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void destroyBlock()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            scene.LoadNextScene();
        }
    }
}