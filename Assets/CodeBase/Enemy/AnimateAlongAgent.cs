using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        public NavMeshAgent Agent;
        public EnemyAnimator Animator;
        
        private void Update()
        {
            if(ShutMove())
                Animator.Move(Agent.velocity.magnitude);
            else
                Animator.StopMoving();
        }

        private bool ShutMove() => 
            Agent.velocity.magnitude > MinimalVelocity && Agent.remainingDistance > Agent.radius;
    }
}