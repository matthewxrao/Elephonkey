using System;

namespace Elephonkey.Service
{
    public static class FinalPoints
    {
        private static int _finalDemocraticPoints = 0;
        public static int FinalDemocraticPoints
        {
            get => _finalDemocraticPoints;
            set
            {
                if (_finalDemocraticPoints != value)
                {
                    _finalDemocraticPoints = value;
                    OnFinalDemocraticPointsChanged?.Invoke(null, EventArgs.Empty);
                    OnPointsChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnFinalDemocraticPointsChanged;

        private static int _finalRepublicanPoints = 0;
        public static int FinalRepublicanPoints
        {
            get => _finalRepublicanPoints;
            set
            {
                if (_finalRepublicanPoints != value)
                {
                    _finalRepublicanPoints = value;
                    OnFinalRepublicanPointsChanged?.Invoke(null, EventArgs.Empty);
                    OnPointsChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnFinalRepublicanPointsChanged;

        private static int _finalLibertarianPoints = 0;
        public static int FinalLibertarianPoints
        {
            get => _finalLibertarianPoints;
            set
            {
                if (_finalLibertarianPoints != value)
                {
                    _finalLibertarianPoints = value;
                    OnFinalLibertarianPointsChanged?.Invoke(null, EventArgs.Empty);
                    OnPointsChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnFinalLibertarianPointsChanged;

        private static int _finalGreenPoints = 0;
        public static int FinalGreenPoints
        {
            get => _finalGreenPoints;
            set
            {
                if (_finalGreenPoints != value)
                {
                    _finalGreenPoints = value;
                    OnFinalGreenPointsChanged?.Invoke(null, EventArgs.Empty);
                    OnPointsChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnFinalGreenPointsChanged;

        private static int _finalOtherPoints = 0;
        public static int FinalOtherPoints
        {
            get => _finalOtherPoints;
            set
            {
                if (_finalOtherPoints != value)
                {
                    _finalOtherPoints = value;
                    OnFinalOtherPointsChanged?.Invoke(null, EventArgs.Empty);
                    OnPointsChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler OnFinalOtherPointsChanged;

        private static bool _quizActive = true;
        public static bool QuizActive
        {
            get => _quizActive;
            set
            {
                if (_quizActive != value)
                {
                    _quizActive = value;
                    OnQuizActiveChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static string ResultText { get; private set; }
        public static string ResultColor { get; private set; }

        // Method to update result
        public static void UpdateResult()
        {
            // Get the points from FinalPoints
            int democraticPoints = FinalDemocraticPoints;
            int republicanPoints = FinalRepublicanPoints;
            int greenPoints = FinalGreenPoints;
            int libertarianPoints = FinalLibertarianPoints;
            int otherPoints = FinalOtherPoints;

            // Calculate liberal and conservative scores
            int liberalScore = democraticPoints + greenPoints;
            int conservativeScore = republicanPoints + libertarianPoints;

            // Determine the political leaning
            if (liberalScore > conservativeScore)
            {
                // More liberal leaning
                ResultText = "liberal";
                ResultColor = "blue";
            }
            else if (conservativeScore > liberalScore)
            {
                // More conservative leaning
                ResultText = "conservative";
                ResultColor = "red";
            }
            else
            {
                // Balanced or neutral leaning
                ResultText = "moderate";
                ResultColor = "purple";
            }

            // Further refine the classification based on the extremity of the scores
            int totalPoints = democraticPoints + republicanPoints + greenPoints + libertarianPoints + otherPoints;
            double liberalRatio = (double)liberalScore / totalPoints;
            double conservativeRatio = (double)conservativeScore / totalPoints;

            if (liberalRatio > 0.7)
            {
                ResultText = "radical";
                ResultColor = "green";
            }
            else if (conservativeRatio > 0.7)
            {
                ResultText = "reactionary";
                ResultColor = "yellow";
            }

            // Raise event indicating result change
            OnResultChanged?.Invoke(null, EventArgs.Empty);
        }

        // Event for result change
        public static event EventHandler OnResultChanged;

        public static event EventHandler OnQuizActiveChanged;

        public static event EventHandler OnPointsChanged;
    }
}