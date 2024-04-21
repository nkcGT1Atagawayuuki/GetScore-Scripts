namespace Utility
{
    public interface IStateTransitionable
    {
        /// <summary>
        /// fromからtoの遷移条件を追加する
        /// </summary>
        void AddTransition<TState>(TState fromState, TState toState) where TState : State;

        /// <summary>
        /// ステートの遷移を行う
        /// </summary>
        void TransitionTo<TState>(TState fromState, TState toState) where TState : State;
    }
}