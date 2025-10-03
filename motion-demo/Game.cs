// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2[] positions = 
            [
                new Vector2(200, 200),
                new Vector2 (50, 50),
                new Vector2 (350, 350),
                new Vector2 (75, 325),
                new Vector2 (275, 40),
                new Vector2 (225, 375),
            ];
        int[] radii;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Motion Demo");
            Window.SetSize(400, 400);
            radii = new int[positions.Length];
            for (int i = 0; i < radii.Length; i++)
            {
                radii[i] = Random.Integer(10, 50);
            }
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            for (int i = 0; i < positions.Length; i += 1)
            {
                Vector2 position = positions[i];
                int radius = radii[i];
                float corneaR = radius;
                float irisR = radius * 0.7f;
                float pupilR = radius * 0.35f;
                DrawEyeball(position, corneaR, irisR, pupilR);
            }
        }

        void DrawEyeball(Vector2 eyePosition, float corneaR, float irisR, float pupilR)
        {
            //get both X and Y coordinates as a vector
            Vector2 mousePosition = Input.GetMousePosition();
            //to go from A to B, B minus A
            Vector2 vectorFromEyeToMouse = mousePosition - eyePosition;
            //split vector into direction and magnitude (distance)
            Vector2 direction = Vector2.Normalize(vectorFromEyeToMouse);
            float distance = vectorFromEyeToMouse.Length();
            //
            Vector2 irisPosition = eyePosition + direction * (corneaR - irisR); // 35 px

            //cornea
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.White;
            Draw.Circle(eyePosition, corneaR);
            //iris
            Draw.FillColor = Color.Cyan;
            Draw.Circle(irisPosition, irisR);
            //pupil
            Draw.FillColor = Color.Black;
            Draw.Circle(irisPosition, pupilR);
        }
    }

}
