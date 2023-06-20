namespace TestWork.DI.Core {
    public class ProjectContext : DIContext {
        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }
    
    }
}
