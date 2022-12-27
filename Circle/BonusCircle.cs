using SFML.Graphics;
using SFML.System;


namespace Rect
{
    public class BonusCircle : Circle
    {
        private static Color Color = new Color(50, 250, 50);


        public BonusCircle(Vector2f position, float movementSpeed, IntRect movementBounds) : base(position, movementSpeed, movementBounds)
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
