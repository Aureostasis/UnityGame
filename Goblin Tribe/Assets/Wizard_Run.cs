using UnityEngine;

public class Wizard_Run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    BossMovement boss;

    public float attackRange = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossMovement>();
        boss.canMove = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || boss == null) return;

        if (Vector2.Distance(player.position, rb.position) <= attackRange &&
            Time.time >= boss.lastAttackTime + boss.attackCooldown)
        {
            animator.SetTrigger("Attack1");
            boss.lastAttackTime = Time.time;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
    }
}
