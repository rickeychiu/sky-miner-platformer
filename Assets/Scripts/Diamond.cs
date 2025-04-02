using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public ParticleSystem ps;
    public SpriteRenderer sprite;
    public bool collected;
    public AudioManager am;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collected) {
            collision.GetComponent<PlayerDiamonds>().diamonds += 1;
            collision.GetComponent<PlayerDiamonds>().UpdateText();
            ps.Play();
            am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            am.PlaySound(am.sfx[5]);
            collected = true;
            sprite.enabled = false;
        }
        else if (collision.gameObject.CompareTag("MainCamera")) {
            Destroy(gameObject);
        }
    }
}
