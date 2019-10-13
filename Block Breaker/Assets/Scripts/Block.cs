using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector3 posBlock;
    [SerializeField] AudioClip blockBreakSounds;
    [SerializeField] Level level;
    [SerializeField] GameObject blockSparklesVFX;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collideBlock();
    }
    void collideBlock()
    {
        Destroy(gameObject);
        TriggerSparkleVFX();
        FindObjectOfType<GameState>().AddPointsToScore();
        level.destroyBlock();
        AudioSource.PlayClipAtPoint(blockBreakSounds, Camera.main.transform.position);
    }
    public void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
