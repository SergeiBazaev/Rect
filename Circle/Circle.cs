using SFML.Graphics;
using SFML.System;


namespace Rect
{
    public class Circle
    {
        public static float DefoltSize = 50;
        public bool IsActive = true;

        protected CircleShape shape;
        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public Circle(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new CircleShape(DefoltSize);
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();

        }

        public void Move()
        {
            shape.Position = Mathf.MoveToward(shape.Position, movementTarget, movementSpeed);



            if (shape.Position == movementTarget)
            {
                OnReachTarget();
                UpdateMovementTarget();
            }
        }

        public void Draw(RenderWindow win)
        {
            if (IsActive == false) return;
            win.Draw(shape);
        }

        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.Radius *2f &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.Radius* 2f)
            {
                OnClick();
            }
        }

        protected void UpdateMovementTarget()
        {


            movementTarget.X = Mathf.random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

        protected virtual void OnClick()
        {

        }

        protected virtual void OnReachTarget()
        {

        }
    }
}
