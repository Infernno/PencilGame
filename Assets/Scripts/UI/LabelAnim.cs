using System.Collections;
using UnityEngine;

public class LabelAnim : MonoBehaviour
{
    public bool Loop;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (anim != null)
        {
            anim.SetBool("Loop", Loop);

            if (!Loop)
            {
                anim.speed = 2f;
                GameManager.Instance.BlockDestroyed += () => { StartCoroutine("Animate"); };
            }
        }
    }

    private IEnumerator Animate()
    {
        anim.SetBool("Loop", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("Loop", false);

        StopCoroutine("Animate");
    }
}