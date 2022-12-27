using SFML.Graphics;
using SFML.System;



namespace Rect
{
    public class EnemyCircle : Circle
    {
        private static Color Color = new Color(250, 50, 50);
        private static float MaxMovmentSpees = 10;
        private static float MovmentStep = 0.1f;
        private static float MaxSize = 170;
        private static float SizeStep = 10;
        private static float BonusSize = 100;


        public EnemyCircle(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.IsLost = true;
        }

        protected override void OnReachTarget()
        {
            if (movementSpeed < MaxMovmentSpees)
            {
                movementSpeed += MovmentStep;
            }
            if (shape.Radius < MaxSize)
            {
                shape.Radius += SizeStep;
            }
            
            if (shape.Radius == BonusSize)
            {
                Mathf.IsBonusCircle = true;
                
            }
            if (Mathf.IsClickBonus == true)
            {

                shape.Radius = 10;
                Mathf.IsClickBonus = false;
            }
        }
    }
}
