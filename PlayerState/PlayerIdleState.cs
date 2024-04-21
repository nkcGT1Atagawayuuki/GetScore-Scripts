using Utility;

public class PlayerIdleState : State, IServiceLocatorGetInstanceable
{
    private IPlayerIdleAction idleAction;
    private IPlayerAnimatorAction animatorAction;

    public override void OnAwake()
    {
        ((IServiceLocatorGetInstanceable)this).GetInstance();
    }

    public override void OnEnter()
    {
        idleAction.ResetMoveVelocity();
        idleAction.ResetCurrentMoveTime();
        animatorAction.ResetMoveSpeed();
    }

    public override void OnUpdate()
    {
        animatorAction.UpdateMoveSpeed();
    }

    public override void OnFixedUpdate()
    {
        idleAction.TransitionToMoveStateOnInput();
    }

    void IServiceLocatorGetInstanceable.GetInstance()
    {
        idleAction = ServiceLocator.GetInstance<IPlayerIdleAction>();
        animatorAction = ServiceLocator.GetInstance<IPlayerAnimatorAction>();
    }
}
