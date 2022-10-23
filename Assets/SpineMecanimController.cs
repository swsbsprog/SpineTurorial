using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class SpineMecanimController : MonoBehaviour
{
    public Animator animator;
    public SkeletonMecanim skeletonMecanim;
    private float speed = 2f;
    void Update()
    {
        Vector2 move = new Vector2(0, 0); //Vector2.zero
        if (Input.GetKey(KeyCode.W)) move.y = 1; // 위
        if (Input.GetKey(KeyCode.S)) move.y = -1; // 아래
        if (Input.GetKey(KeyCode.A)) move.x = -1; // 좌
        if (Input.GetKey(KeyCode.D)) move.x = 1; // 우
        move.Normalize(); // 길이 1로 만들기
        animator.SetFloat("speed", move.magnitude);
        transform.Translate(speed * Time.deltaTime * move);
        FlipX(move.x);
    }

    private void FlipX(float x) // 
    {
        if (x == 0)
            return;
        skeletonMecanim.Skeleton.ScaleX = x > 0 ? 1 : -1;
    }
}
