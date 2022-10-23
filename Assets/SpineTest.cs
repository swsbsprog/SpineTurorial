using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTest : MonoBehaviour
{
    [SpineAnimation]
    public string animationName;
    public int track = 0;
    void Start()
    {
        SkeletonAnimation sa = GetComponent<SkeletonAnimation>();
        sa.AnimationState.SetAnimation(track, animationName, true);
        //sa.AnimationState.SetAnimation(track, "blink", true);
    }
}
