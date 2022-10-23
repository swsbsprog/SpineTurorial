using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTest : MonoBehaviour
{
    [SpineAnimation]
    public string animationName;
    [SpineAnimation]
    public string addAnimationName;
    public int track = 0;
    public float scaleX = 1;

    SkeletonAnimation sa;
    void Start()
    {
        sa = GetComponent<SkeletonAnimation>();
        sa.AnimationState.SetAnimation(track, animationName, false);
        sa.AnimationState.AddAnimation(track, addAnimationName, true, 0);
        //UpdateScale(sa);
    }

    [ContextMenu("UpdateScale")]
    private void UpdateScale()
    {
        sa.Skeleton.ScaleX = scaleX;
    }
}
