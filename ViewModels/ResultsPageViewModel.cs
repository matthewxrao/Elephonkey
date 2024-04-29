using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Elephonkey.Models;
using Elephonkey.Service;
using Elephonkey.Views;
using Microcharts;
using SkiaSharp;
using System;
using System.ComponentModel;

namespace Elephonkey.ViewModels
{
    public partial class ResultsPageViewModel : ObservableObject
    {
        // Variables

        private bool _quizIncomplete = FinalPoints.QuizActive;
        public bool QuizIncomplete
        {
            get => _quizIncomplete;
            set => SetProperty(ref _quizIncomplete, value);
        }

        private bool _quizComplete = !FinalPoints.QuizActive;
        public bool QuizComplete
        {
            get => _quizComplete;
            set => SetProperty(ref _quizComplete, value);
        }

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set
            {
                if (_resultText != value)
                {
                    _resultText = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _resultColor;
        public string ResultColor
        {
            get => _resultColor;
            set
            {
                if (_resultColor != value)
                {
                    _resultColor = value;
                    OnPropertyChanged();
                }
            }
        }

        // Constructor
        public ResultsPageViewModel()
        {
            // Subscribe to events in FinalPoints
            FinalPoints.OnQuizActiveChanged += FinalPoints_OnQuizActiveChanged;
            FinalPoints.OnFinalDemocraticPointsChanged += FinalPoints_OnPointsChanged;
            FinalPoints.OnFinalRepublicanPointsChanged += FinalPoints_OnPointsChanged;
            FinalPoints.OnFinalLibertarianPointsChanged += FinalPoints_OnPointsChanged;
            FinalPoints.OnFinalGreenPointsChanged += FinalPoints_OnPointsChanged;
            FinalPoints.OnFinalOtherPointsChanged += FinalPoints_OnPointsChanged;

            // Update initial values
            UpdatePoints();
            CalculateResult();
        }

        private void FinalPoints_OnQuizActiveChanged(object sender, EventArgs e)
        {
            QuizIncomplete = FinalPoints.QuizActive;
            QuizComplete = !FinalPoints.QuizActive;
        }

        private void FinalPoints_OnPointsChanged(object sender, EventArgs e)
        {
            // Update integer properties when points change
            UpdatePoints();
        }

        public void UpdatePoints()
        {
            DemocraticPoints = FinalPoints.FinalDemocraticPoints;
            RepublicanPoints = FinalPoints.FinalRepublicanPoints;
            LibertarianPoints = FinalPoints.FinalLibertarianPoints;
            GreenPoints = FinalPoints.FinalGreenPoints;
            OtherPoints = FinalPoints.FinalOtherPoints;
        }

        public void CalculateResult()
        {
            // Get the points from FinalPoints
            int democraticPoints = FinalPoints.FinalDemocraticPoints;
            int republicanPoints = FinalPoints.FinalRepublicanPoints;
            int greenPoints = FinalPoints.FinalGreenPoints;
            int libertarianPoints = FinalPoints.FinalLibertarianPoints;
            int otherPoints = FinalPoints.FinalOtherPoints;

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
        }

        // Integer properties for points
        private int _democraticPoints;
        public int DemocraticPoints
        {
            get => _democraticPoints;
            set => SetProperty(ref _democraticPoints, value);
        }

        private int _republicanPoints;
        public int RepublicanPoints
        {
            get => _republicanPoints;
            set => SetProperty(ref _republicanPoints, value);
        }

        private int _libertarianPoints;
        public int LibertarianPoints
        {
            get => _libertarianPoints;
            set => SetProperty(ref _libertarianPoints, value);
        }

        private int _greenPoints;
        public int GreenPoints
        {
            get => _greenPoints;
            set => SetProperty(ref _greenPoints, value);
        }

        private int _otherPoints;
        public int OtherPoints
        {
            get => _otherPoints;
            set => SetProperty(ref _otherPoints, value);
        }

        // Retake Quiz Command
        [RelayCommand]
        private void RetakeQuiz()
        {
            // Navigate back to the survey page
            Shell.Current.GoToAsync(state: "//Survey");

            // Reset points
            FinalPoints.FinalDemocraticPoints = 0;
            FinalPoints.FinalRepublicanPoints = 0;
            FinalPoints.FinalLibertarianPoints = 0;
            FinalPoints.FinalGreenPoints = 0;
            FinalPoints.FinalOtherPoints = 0;

            UpdatePoints();
            CalculateResult();

            // Set QuizActive to false
            FinalPoints.QuizActive = true;
        }
    }
}