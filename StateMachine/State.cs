namespace Utility
{
    public abstract class State
    {
        /// <summary>
        /// ステートが初めて実行されたか
        /// </summary>
        public bool IsAwake = false;

        /// <summary>
        /// 現在のステートが初めて実行された時に、最初に実行される
        /// 二回目移行はこの処理は実行されない。
        /// </summary>
        public virtual void OnAwake() { }

        /// <summary>
        /// ステート開始時に実行される
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// 固定フレーム実行される
        /// </summary>
        public virtual void OnFixedUpdate() { }

        /// <summary>
        /// 毎フレーム実行される
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// 毎フレームの最後に実行される
        /// </summary>
        public virtual void OnLateUpdate() { }

        /// <summary>
        /// ステート終了時に実行される
        /// </summary>
        public virtual void OnExit() { }
    }
}