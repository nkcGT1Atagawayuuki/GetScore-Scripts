using System;
using UnityEngine;

namespace Utility
{
    public class StateBaseController : MonoBehaviour, IStateAnyTransitionable, IStateTransitionable
    {
        [Header("�ŏ��ɏ���������X�e�[�g�N���X�̖��O")]�@
        [SerializeField] private string startInitializeStateName;

        private StateBase stateBase = new StateBase();

        private async void Start()
        {
            // �T�[�r�X���P�[�^�[����擾����N���X��null�ɂȂ�Ȃ��悤��1�t���[���҂�
            await AsyncDelayManager.DelayFrameAsync(1);
            SetInitializeState();
        }

        /// <summary>
        /// ����������X�e�[�g��ݒ肷��
        /// </summary>
        private void SetInitializeState()
        {
            // ���O�̃N���X���擾����
            var stateType = Type.GetType(startInitializeStateName);

            // �N���X�����݂��Ȃ��ꍇ�̓G���[���O��Ԃ�
            if (stateType == null)
            {
                Debug.LogError($"{startInitializeStateName}�͑��݂��Ȃ��N���X�A�܂���string�̃N���X�����ԈႦ�Ă���\��������܂��B");
                return;
            }

            // �T�[�r�X���P�[�^�[��GetInstance���\�b�h���擾���āA��������stateType��n��
            var getInstance = typeof(ServiceLocator).GetMethod("GetInstance").MakeGenericMethod(stateType);

            // ���������ݒ肳�ꂽGetInstance���\�b�h�����s���ď���������X�e�[�g���擾����
            var initializeState = getInstance.Invoke(null, null) as State;
            stateBase.InitializeState(initializeState);
        }

        private void Update()
        {
            stateBase?.Update();
        }

        private void FixedUpdate()
        {
            stateBase?.FixedUpdate();
        }

        private void LateUpdate()
        {
            stateBase?.LateUpdate();
        }

        void IStateTransitionable.AddTransition<TState>(TState fromState, TState toState)
        {
            stateBase?.AddTransition(fromState, toState);
        }

        void IStateTransitionable.TransitionTo<TState>(TState fromState, TState toState)
        {
            stateBase?.TransitionTo(fromState, toState);
        }

        void IStateAnyTransitionable.AnyTransition<TState>(TState nextState)
        {
            stateBase?.AnyTransitionTo(nextState);
        }
    }
}
