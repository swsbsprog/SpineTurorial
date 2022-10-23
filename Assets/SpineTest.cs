using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTest : MonoBehaviour
{
    public int track = 0;
    void Start()
    {
        SkeletonAnimation sa = GetComponent<SkeletonAnimation>();
        sa.AnimationState.SetAnimation(track, "blink", true);
    }
}
