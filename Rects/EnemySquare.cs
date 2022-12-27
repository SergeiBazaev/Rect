using SFML.Graphics;
using SFML.System;


namespace Rect
{
    public class EnemySquare : Square
    {
        private static Color Color = new Color(250, 50, 50);
        private static float MaxMovmentSpees = 1;
        private static float MovmentStep = 0.1f;
        private static float MaxSize = 300;
        private static float SizeStep = 10;
        private static float BonusSize = 150;



        public EnemySquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds) 
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.IsLost = true;
        }
        
        protected override void OnReachTarget()
        {
            if(movementSpeed < MaxMovmentSpees)
            {
                movementSpeed += MovmentStep;
            }
            if(shape.Size.X < MaxSize)
            {
                shape.Size += new Vector2f(SizeStep, SizeStep);
            }

            if (shape.Size.X == BonusSize)
            {
                Mathf.IsBonusSquare = true;
               
            }
            if(Mathf.IsClickBonus == true)
            {
                
                shape.Size = new Vector2f(10, 10);
                Mathf.IsClickBonus = false;
            }
        }
        
    }
}
