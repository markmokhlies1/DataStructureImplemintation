using System.Drawing;

namespace SearchThePicture
{
    public interface IPlayersFinder
    {
        Point[] FindPlayers(string[] photo, int team, int threshold);
    }
}
