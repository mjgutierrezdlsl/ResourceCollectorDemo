namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class WalkState : State<GoblinStateMachine>
    {
        GoblinStateMachine _context;
        public WalkState(string name) : base(name)
        {
        }
        protected override void OnEnterState()
        {
            base.OnEnterState();
            Context.Animator.SetBool("isMoving", true);
        }
    }

}