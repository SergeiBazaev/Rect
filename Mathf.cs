using System;

using SFML.System;



namespace Rect
{
    public static class Mathf
    {
        public static Random random = new Random();

        public static Vector2f MoveToward(Vector2f curent, Vector2f target, float maxDistanceDelta)
        {
            Vector2f dir = target - curent;
            float magnitude = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            if (magnitude <= maxDistanceDelta || magnitude == 0)
            {
                return target;
            }


            return curent + dir / magnitude * maxDistanceDelta;

        }

        public static bool IsBonusSquare = false;
        public static bool IsBonusCircle = false;

        public static bool IsClickBonus = false;
        public static bool IsStartChoose = true;
        public static string Tag;
    }

    
}
