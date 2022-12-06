
namespace Pumpkin
{
	public abstract class Module
	{
        #region 接口
        public abstract void Awake();
		public abstract void Init();
		public abstract void AfterInit();
		public abstract void Execute();
		public abstract void BeforeShut();
		public abstract void Shut();
        #endregion

        #region 成员
        public PluginManager m_PluginManager;
        public string m_Name;
        #endregion
    };
}
