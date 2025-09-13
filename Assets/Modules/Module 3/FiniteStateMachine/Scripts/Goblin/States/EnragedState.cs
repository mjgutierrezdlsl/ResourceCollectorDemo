using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class EnragedState : State<GoblinStateMachine>
    {
        public EnragedState(string name) : base(name)
        {
        }
        protected override void OnUpdateState()
        {
            base.OnUpdateState();
            if (Context.Health <= 0)
            {
                Context.ChangeState(Context.Dead);
            }
        }
    }
}
