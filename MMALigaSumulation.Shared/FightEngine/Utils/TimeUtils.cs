namespace MMALigaSumulation.Shared.FightEngine.Utils
{
    public class TimeUtils
    {

        public static string GetTime(int currentTime)
        {
            int min = currentTime / 60;
            int sec = currentTime % 60;

            return sec > 9 ? $"{min}:{sec}" : $"{min}:0{sec}";
        }

    }
}
