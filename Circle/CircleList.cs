using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System.Collections.Generic;


namespace Rect
{
    public class CircleList
    {
        private List<Circle> circles = new List<Circle>();
        public bool CircleHasRemovd;
        public Circle RemovdCircle;

        public CircleList()
        {
            circles = new List<Circle>();
        }

        public void Reset()
        {
            CircleHasRemovd = false;
            RemovdCircle = null;
            circles.Clear();
        }

        public void Update(RenderWindow window)
        {
            
                CircleHasRemovd = false;
                RemovdCircle = null;
           

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {

                    for (int i = 0; i < circles.Count; i++)
                    {
                        circles[i].CheckMousePosition(Mouse.GetPosition(window));
                    }
                

            }

                for (int i = 0; i < circles.Count; i++)
                {
                    circles[i].Move();
                    circles[i].Draw(window);

                    if (circles[i].IsActive == false)
                    {
                        RemovdCircle = circles[i];
                        circles.Remove(circles[i]);
                        CircleHasRemovd = true;
                    }
                }
            
        }

        public void SpownPlayerCircle()
        {

                circles.Add(new PlayerCircle(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 600, 400)));
            

        }

        public void SpownEnemyCircle()
        {
                circles.Add(new EnemyCircle(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 600, 400)));
           
        }



        public void SpownBonusCircle()
        {
        
                circles.Add(new BonusCircle(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 600, 400)));
            
        }

    }
}
