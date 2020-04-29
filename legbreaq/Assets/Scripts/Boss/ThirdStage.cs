using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage : StateMachineBehaviour
{
    private Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        boss.startTimeBetweenShots = 0.7f;
        boss.timeBetweenShots = 0.1f;
        boss.bigSpawn();
        if (boss.health < 10)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(go);
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.thirdStage();
    }
}
