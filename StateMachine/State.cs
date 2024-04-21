namespace Utility
{
    public abstract class State
    {
        /// <summary>
        /// �X�e�[�g�����߂Ď��s���ꂽ��
        /// </summary>
        public bool IsAwake = false;

        /// <summary>
        /// ���݂̃X�e�[�g�����߂Ď��s���ꂽ���ɁA�ŏ��Ɏ��s�����
        /// ���ڈڍs�͂��̏����͎��s����Ȃ��B
        /// </summary>
        public virtual void OnAwake() { }

        /// <summary>
        /// �X�e�[�g�J�n���Ɏ��s�����
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// �Œ�t���[�����s�����
        /// </summary>
        public virtual void OnFixedUpdate() { }

        /// <summary>
        /// ���t���[�����s�����
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// ���t���[���̍Ō�Ɏ��s�����
        /// </summary>
        public virtual void OnLateUpdate() { }

        /// <summary>
        /// �X�e�[�g�I�����Ɏ��s�����
        /// </summary>
        public virtual void OnExit() { }
    }
}