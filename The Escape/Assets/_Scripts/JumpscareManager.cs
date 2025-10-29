using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareManager : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioSource jumpscareSound;
    public float fadeInSpeed = 2f;
    private bool triggered = false;

    public void TriggerJumpscare()
    {
        if (triggered) return;
        triggered = true;
        StartCoroutine(JumpscareSequence());
    }

    private System.Collections.IEnumerator JumpscareSequence()
    {
        jumpscareSound?.Play();

        Color color = jumpscareImage.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime * fadeInSpeed;
            jumpscareImage.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart
    }
}
