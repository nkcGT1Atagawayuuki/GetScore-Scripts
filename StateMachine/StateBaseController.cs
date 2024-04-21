using System;
using UnityEngine;

namespace Utility
{
    public class StateBaseController : MonoBehaviour, IStateAnyTransitionable, IStateTransitionable
    {
        [Header("最初に初期化するステートクラスの名前")]　
        [SerializeField] private string startInitializeStateName;

        private StateBase stateBase = new StateBase();

        private async void Start()
        {
            // サービスロケーターから取得するクラスがnullにならないように1フレーム待つ
            await AsyncDelayManager.DelayFrameAsync(1);
            SetInitializeState();
        }

        /// <summary>
        /// 初期化するステートを設定する
        /// </summary>
        private void SetInitializeState()
        {
            // 名前のクラスを取得する
            var stateType = Type.GetType(startInitializeStateName);

            // クラスが存在しない場合はエラーログを返す
            if (stateType == null)
            {
                Debug.LogError($"{startInitializeStateName}は存在しないクラス、またはstringのクラス名を間違えている可能性があります。");
                return;
            }

            // サービスロケーターのGetInstanceメソッドを取得して、引き数にstateTypeを渡す
            var getInstance = typeof(ServiceLocator).GetMethod("GetInstance").MakeGenericMethod(stateType);

            // 引き数が設定されたGetInstanceメソッドを実行して初期化するステートを取得する
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
