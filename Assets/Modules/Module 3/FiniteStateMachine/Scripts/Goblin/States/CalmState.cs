using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class CalmState : State<GoblinStateMachine>
    {
        public CalmState(string name) : base(name)
        {
        }
        protected override void OnUpdateState()
        {
            base.OnUpdateState();
            if (Mathf.InverseLerp(0, Context.MaxHealth, Context.Health) <= 0.5f)
            {
                Context.ChangeState(Context.EnragedWalk);
            }
        }
    }
}
