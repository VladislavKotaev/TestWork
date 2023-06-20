namespace TestWork.UI {
    public interface IWindow {
        public WindowType Type { get; }
        public void Open();
        public void Close();
    }
}
