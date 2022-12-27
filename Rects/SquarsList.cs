using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System.Collections.Generic;


namespace Rect
{
    public class SquarsList
    {
       private List<Square> squares = new List<Square>();
        public bool SquareHasRemovd;
        public Square RemovdSquare;

      

        public SquarsList()
        {
           
                squares = new List<Square>();
        
        }
        

        public void Reset()
        {
           
                SquareHasRemovd = false;
                RemovdSquare = null;
                squares.Clear();
          
        }

        public void Update(RenderWindow window)
        {
          
                SquareHasRemovd = false;
                RemovdSquare = null;
 
            

            

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
           
                   for (int i = 0; i < squares.Count; i++)
                    {
                        squares[i].CheckMousePosition(Mouse.GetPosition(window));
                        
                    }
            
                
            }

          
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].Move();
                   
                    squares[i].Draw(window);
                   
                    if (squares[i].IsActive == false)
                    {
                        RemovdSquare = squares[i];
                        squares.Remove(squares[i]);
                        SquareHasRemovd = true;
                    }
                }
           
        }
        
        public void SpownPlayerSquare()
        {
            
                squares.Add(new PlayerSquare(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
           
        }

        public void SpownEnemySquare()
        {
            
                squares.Add(new EnemySquare(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
            
        }

        

        public void SpownBonusSquare()
        {
            
                squares.Add(new BonusSquare(new Vector2f(Mathf.random.Next(0, 800), Mathf.random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        
        }
       

    }
}
