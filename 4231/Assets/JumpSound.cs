using UnityEngine;

public class PlaySoundOnAnimation : StateMachineBehaviour
{
    public AudioClip jumpSound;
    public float delay = 0.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AudioSource>().PlayOneShot(jumpSound, delay);
    }
}
