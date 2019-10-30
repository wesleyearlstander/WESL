namespace WESL
{
    public interface ITimer
    {
        float startTime { get; }
        float duration { get; }
        float endTime { get; }
        float getGlobalTime();
        float GetPercentage();
        float GetTime();
        bool IsDone();
        bool IsReversed();
        void Reset();
        void Reset(float duration);
        void Reverse();
        void Reverse(float duration);
        void SetPercentage(float percentage);
        void SetTime(float time);
        string ToString();
    }
}