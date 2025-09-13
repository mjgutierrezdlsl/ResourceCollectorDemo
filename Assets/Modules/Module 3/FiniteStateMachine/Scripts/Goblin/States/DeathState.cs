using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class DeathState : State<GoblinStateMachine>
    {
        public DeathState(string name) : base(name)
        {
        }
        protected override void OnEnterState()
        {
            base.OnEnterState();
            Context.Animator.SetTrigger("die");
        }
    }
}
