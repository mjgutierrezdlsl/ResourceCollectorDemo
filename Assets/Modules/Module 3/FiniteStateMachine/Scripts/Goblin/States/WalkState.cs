namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class WalkState : State
    {
        GoblinStateMachine _context;
        public WalkState(string name) : base(name)
        {
        }
        protected override void OnEnterState()
        {
            base.OnEnterState();
            _context = (GoblinStateMachine)Context;
            _context.Animator.SetBool("isMoving", true);
        }
    }

}