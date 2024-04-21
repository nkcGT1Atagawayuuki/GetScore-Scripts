namespace Utility
{
    public interface IStateAnyTransitionable
    {
        /// <summary>
        /// 任意のステートに遷移する
        /// </summary>
        void AnyTransition<TState>(TState nextState) where TState : State;
    }
}