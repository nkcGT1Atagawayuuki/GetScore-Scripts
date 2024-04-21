namespace Utility
{
    public interface IStateTransitionable
    {
        /// <summary>
        /// from����to�̑J�ڏ�����ǉ�����
        /// </summary>
        void AddTransition<TState>(TState fromState, TState toState) where TState : State;

        /// <summary>
        /// �X�e�[�g�̑J�ڂ��s��
        /// </summary>
        void TransitionTo<TState>(TState fromState, TState toState) where TState : State;
    }
}