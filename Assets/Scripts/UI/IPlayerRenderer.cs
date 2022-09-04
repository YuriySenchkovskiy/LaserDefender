namespace UI
{
    public interface IPlayerRenderer<T>
    {
        void SetDataInWidget(T localInfo, int index);
    }
}