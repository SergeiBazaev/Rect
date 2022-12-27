using SFML.Graphics;
using SFML.System;


namespace Rect
{
    public class BonusSquare : Square
    {
        private static Color Color = new Color(50, 250, 50);
       

        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;

        }
        protected override void OnClick()
        {

            Mathf.IsClickBonus = true;
            IsActive = false;
            
              

        }
    }
}
