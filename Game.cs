using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Rect
{
    public class Game
    {
        public static int Scores;
        public static bool IsLost;
        

        private Font myFont;
        private Text restartText;
        private Text scoreText;
        private Text chooseText;


        private SquarsList squars;
        private CircleList circles;

        private int MaxScore;
        public Game() 
        {
            myFont = new Font("comic.ttf");



            


            squars = new SquarsList();
            circles= new CircleList();
            

            scoreText = new Text();
            scoreText.Font = myFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 18;
            scoreText.Position = new Vector2f(10, 10);

            restartText = new Text();
            restartText.Font = myFont;
            restartText.FillColor = Color.Black;
            restartText.DisplayedString = "Ты проиграл! Нажми R, чтобы продолжить игру!";
            restartText.Position = new Vector2f(20, 290);

            chooseText = new Text();
            chooseText.Font = myFont;
            chooseText.FillColor = Color.White;
            chooseText.Position = new Vector2f(100, 190);
            chooseText.DisplayedString = "Чтобы играть квадратами нажми букву S \n \nЧтобы играть кругами нажми букву C";

            Reset();
            
        }

        private void Reset()
        {
            circles.Reset();
            squars.Reset();
            Scores = 0;
            IsLost = false;
            

            squars.SpownPlayerSquare();
            squars.SpownPlayerSquare();
            squars.SpownPlayerSquare();

            squars.SpownEnemySquare();
            squars.SpownEnemySquare();
            squars.SpownEnemySquare();

            circles.SpownPlayerCircle();
            circles.SpownPlayerCircle();
            circles.SpownPlayerCircle();

            circles.SpownEnemyCircle();
            circles.SpownEnemyCircle();
            circles.SpownEnemyCircle();


        }

        

    public void UpDate(RenderWindow window)
        {
            while (Mathf.IsStartChoose == true)
            {

                

                if (Mathf.IsStartChoose == true)
                {
                    window.Clear();
                    window.Draw(chooseText);
                    window.Display();
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true)
                {
                    Mathf.Tag = "Square";
                    Mathf.IsStartChoose = false;
                    break;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.C) == true)
                {
                    Mathf.Tag = "Circle";
                    Mathf.IsStartChoose = false;
                    break;
                }
            }

            if (IsLost == true)
            {
                window.Draw(restartText);

                if (Scores > MaxScore)
                {
                    MaxScore = Scores;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                }
            }
            if (IsLost == false)
            {
                if (Mathf.Tag == "Square")
                {
                    squars.Update(window);
                }
               if (Mathf.Tag == "Circle")
                {
                    circles.Update(window);
                }
                
               
                

                if (Mathf.IsBonusSquare == true)
                {
                    squars.SpownBonusSquare();
                    Mathf.IsBonusSquare = false;
                    
                }

                if (Mathf.IsBonusCircle == true)
                {
                    
                    circles.SpownBonusCircle();
                    Mathf.IsBonusCircle = false;
                    
                }


                if (squars.SquareHasRemovd == true)
                {

                    if (squars.RemovdSquare is PlayerSquare)
                    {
                        squars.SpownPlayerSquare();
                    }

                    if (squars.RemovdSquare is EnemySquare)
                    {
                        squars.SpownEnemySquare();
                    }

                }
                if (circles.CircleHasRemovd == true)
                {

                    if (circles.RemovdCircle is PlayerCircle)
                    {
                        circles.SpownPlayerCircle();
                    }

                    if (circles.RemovdCircle is EnemyCircle)
                    {
                        circles.SpownEnemyCircle();
                    }

                }
            }
            

            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScore.ToString();
            window.Draw(scoreText);
            
        }
    }
}
