namespace Utility
{
    public interface IStateAnyTransitionable
    {
        /// <summary>
        /// �C�ӂ̃X�e�[�g�ɑJ�ڂ���
        /// </summary>
        void AnyTransition<TState>(TState nextState) where TState : State;
    }
}