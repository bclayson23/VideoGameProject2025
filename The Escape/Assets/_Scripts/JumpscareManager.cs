using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareManager : MonoBehaviour
{
    public Image jumpscareImage;
    //public AudioSource jumpscareSound;
    public float fadeInSpeed = 2f;
    private bool triggered = false;

    public MonoBehaviour playerController;

    public void TriggerJumpscare()
    {
        jumpscareImage.enabled = true;
        jumpscareImage.color = Color.white;
        Debug.Log("JUMPSCARE IMAGE FORCED ON");

        if (triggered) return;
        triggered = true;

        if (playerController != null)
            playerController.enabled = false;

        // Ensure image starts fully transparent
        Color start = jumpscareImage.color;
        start.a = 0;
        jumpscareImage.color = start;

        jumpscareImage.enabled = true; // <-- IMPORTANT

        StartCoroutine(JumpscareSequence());
    }

    private IEnumerator JumpscareSequence()
    {
        //jumpscareSound?.Play();

        while (jumpscareImage.color.a < 1f)
        {
            Color c = jumpscareImage.color;
            c.a += Time.deltaTime * fadeInSpeed;
            jumpscareImage.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        FindObjectOfType<UIManager>().ShowGameOver();
    }
}
