using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ContrAnim : StateMachineBehaviour
{
    public string animationName;
    public float speed;
    public bool loop = true;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SkeletonAnimation anim = animator.GetComponent<SkeletonAnimation>();
        anim.state.SetAnimation(0, animationName, loop).TimeScale = speed;
    }
}
