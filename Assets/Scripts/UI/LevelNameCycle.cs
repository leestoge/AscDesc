using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameCycle : MonoBehaviour
{
    public float WaitBetween;
    List<Animator> _animators;

    void Awake()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        while (true)
        {
            foreach (var animator in _animators)
            {
                animator.SetTrigger("DoAnimation");
                yield return new WaitForSeconds(WaitBetween);
            }
        }
    }
}
