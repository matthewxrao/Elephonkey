
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Elephonkey.Models;
using Elephonkey.Service;
using System.Collections.ObjectModel;


namespace Elephonkey.ViewModels
{
    public partial class SurveyPageViewModel : ObservableObject
    {
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();
        public int CurrentQuestionIndex { get; set; }

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

        [ObservableProperty]
        private string _currentQuestion;

        public SurveyPageViewModel()
        {
            // Initialize questions
            Questions = new ObservableCollection<Question>
            {
                new Question
                {
                    Text = "Anyone should be able to get an abortion.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", DemocraticPoints = 3, GreenPoints = 2},
                        new Answer { Text = "Agree", DemocraticPoints = 2, LibertarianPoints = 1,},
                        new Answer { Text = "Neutral", OtherPoints = 1 },
                        new Answer { Text = "Disagree", RepublicanPoints = 2, LibertarianPoints = 1},
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3, }
                    }
                },

                new Question
                {
                    Text = "All guns should be kept legal under the 2nd amendment.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3, LibertarianPoints = 2},
                        new Answer { Text = "Agree", DemocraticPoints = 2, RepublicanPoints = 2, LibertarianPoints = 1},
                        new Answer {Text = "Neutral", OtherPoints = 1},
                        new Answer { Text = "Disagree", DemocraticPoints = 2, GreenPoints = 1},
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, GreenPoints = 2, OtherPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "Publicly provided healthcare is in the best interest of citizens.",
                    Answers = new List<Answer>
                    {
                        new Answer {Text = "Strongly Agree", DemocraticPoints = 3},
                        new Answer { Text = "Agree", DemocraticPoints = 2, GreenPoints = 1 },
                        new Answer {Text = "Neutral", OtherPoints = 1},
                        new Answer { Text = "Disagree", RepublicanPoints = 2, LibertarianPoints = 1},
                        new Answer { Text = "Strongly Disagree",RepublicanPoints = 3, LibertarianPoints = 2}
                    }
                },

                new Question
                {
                    Text = "Capitalism is the best economic system.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3, LibertarianPoints = 2 },
                        new Answer {Text = "Agree", DemocraticPoints = 2, RepublicanPoints = 2},
                        new Answer {Text = "Neutral", OtherPoints = 1},
                        new Answer { Text = "Disagree", DemocraticPoints = 2, GreenPoints = 1 },
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, GreenPoints = 2, OtherPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "I support LGBTQ+ rights.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", DemocraticPoints = 3, GreenPoints = 2 },
                        new Answer { Text = "Agree", DemocraticPoints = 2, LibertarianPoints = 1 },
                        new Answer { Text = "Neutral", LibertarianPoints = 1,},
                        new Answer { Text = "Disagree", RepublicanPoints = 2 },
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3 }
                    }
                },

                new Question
                {
                    Text = "The United States should follow Christian values.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3   },
                        new Answer { Text = "Agree", RepublicanPoints = 3 },
                        new Answer { Text = "Neutral",  LibertarianPoints = 1},
                        new Answer { Text = "Disagree", DemocraticPoints = 2, GreenPoints = 1},
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, GreenPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "Illegal immigration presents threats to national security.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3 },
                        new Answer { Text = "Agree", RepublicanPoints = 2 },
                        new Answer { Text = "Neutral", LibertarianPoints = 1 },
                        new Answer { Text = "Disagree", DemocraticPoints = 2},
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, GreenPoints = 2}
                    }
                },

                new Question
                {
                    Text = "Legal immigration betters the country.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", DemocraticPoints = 3, GreenPoints = 2},
                        new Answer { Text = "Agree", DemocraticPoints = 2, LibertarianPoints = 1 },
                        new Answer { Text = "Neutral", RepublicanPoints = 2 },
                        new Answer { Text = "Disagree", RepublicanPoints = 2 },
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3 }
                    }
                },

                new Question
                {
                    Text = "Diversity is important in the workplace.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", DemocraticPoints = 3, GreenPoints = 2 },
                        new Answer {Text = "Agree", DemocraticPoints = 2},
                        new Answer { Text = "Neutral", RepublicanPoints = 2, LibertarianPoints = 1 },
                        new Answer { Text = "Disagree", RepublicanPoints = 2, LibertarianPoints = 1 },
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3 }
                    }
                },

                new Question
                {
                    Text = "Women face greater hurdles to success than men.",
                    Answers = new List<Answer>
                    {
                        new Answer {Text = "Strongly Agree", DemocraticPoints = 3},
                        new Answer { Text = "Agree", DemocraticPoints = 2},
                        new Answer { Text = "Neutral", OtherPoints = 1 },
                        new Answer { Text = "Disagree", RepublicanPoints = 2 },
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3 }
                    }
                },

                new Question
                {
                    Text = "Minorities face greater hurdles to success than the majority.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", DemocraticPoints = 3, GreenPoints = 2},
                        new Answer { Text = "Agree", LibertarianPoints = 2, GreenPoints = 1},
                        new Answer { Text = "Neutral", RepublicanPoints = 2},
                        new Answer { Text = "Disagree", RepublicanPoints = 2},
                        new Answer { Text = "Strongly Disagree", RepublicanPoints = 3, LibertarianPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "Schools should be able to ban books.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3 },
                        new Answer { Text = "Agree", RepublicanPoints = 2 },
                        new Answer { Text = "Neutral", DemocraticPoints = 2, LibertarianPoints = 1 },
                        new Answer { Text = "Disagree", DemocraticPoints = 2, LibertarianPoints = 1, GreenPoints = 1 },
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, GreenPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "Individual Liberties are extremely important.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", LibertarianPoints = 2 },
                        new Answer { Text = "Agree", LibertarianPoints = 2, OtherPoints = 1 },
                        new Answer { Text = "Neutral", DemocraticPoints = 2, RepublicanPoints = 2, GreenPoints = 1 },
                        new Answer { Text = "Disagree", OtherPoints = 1 },
                        new Answer { Text = "Strongly Disagree", OtherPoints = 2 }
                    }
                },

                new Question
                {
                    Text = "US foreign military intervention is necessary.",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Strongly Agree", RepublicanPoints = 3 },
                        new Answer { Text = "Agree", RepublicanPoints = 2 },
                        new Answer { Text = "Neutral", OtherPoints = 1},
                        new Answer { Text = "Disagree", DemocraticPoints = 2, LibertarianPoints = 1, GreenPoints = 1 },
                        new Answer { Text = "Strongly Disagree", DemocraticPoints = 3, LibertarianPoints = 2, GreenPoints = 2 }
                    }
                }
            };

            // Set initial question index and subscribe to events    
            CurrentQuestionIndex = 0;
            CurrentQuestion = Questions[CurrentQuestionIndex].Text;
             
            FinalPoints.OnQuizActiveChanged += FinalPoints_OnQuizActiveChanged;

            // Update quiz status
            UpdateQuizStatus();
        }

        // Event handler for changes in quiz activity
        private void FinalPoints_OnQuizActiveChanged(object sender, EventArgs e)
        {
            UpdateQuizStatus();
        }

        private void UpdateQuizStatus()
        {
            QuizIncomplete = FinalPoints.QuizActive;
            QuizComplete = !FinalPoints.QuizActive;
        }

        [RelayCommand]
        public void StronglyAgree()
        {
            // Update final points based on answer
            UpdateFinalPoints(Questions[CurrentQuestionIndex].Answers[0]);

            // Move to the next question
            MoveToNextQuestion();
        }

        [RelayCommand]
        public void Agree()
        {

            // Update final points based on answer
            UpdateFinalPoints(Questions[CurrentQuestionIndex].Answers[1]);

            // Move to the next question
            MoveToNextQuestion();
        }

        [RelayCommand]
        public void Neutral()
        {
            // Update final points based on answer
            UpdateFinalPoints(Questions[CurrentQuestionIndex].Answers[2]);

            // Move to the next question
            MoveToNextQuestion();
        }

        [RelayCommand]
        public void Disagree()
        {

            // Update final points based on answer
            UpdateFinalPoints(Questions[CurrentQuestionIndex].Answers[3]);

            // Move to the next question
            MoveToNextQuestion();
        }

        [RelayCommand]
        public void StronglyDisagree()
        {

            // Update final points based on answer
            UpdateFinalPoints(Questions[CurrentQuestionIndex].Answers[4]);

            // Move to the next question
            MoveToNextQuestion();
        }

        // Method to update final points based on the selected answer
        private void UpdateFinalPoints(Answer selectedAnswer)
        {
            FinalPoints.FinalDemocraticPoints += selectedAnswer.DemocraticPoints;
            FinalPoints.FinalRepublicanPoints += selectedAnswer.RepublicanPoints;
            FinalPoints.FinalLibertarianPoints += selectedAnswer.LibertarianPoints;
            FinalPoints.FinalGreenPoints += selectedAnswer.GreenPoints;
            FinalPoints.FinalOtherPoints += selectedAnswer.OtherPoints;
        }
        private void MoveToNextQuestion()
        {
            CurrentQuestionIndex++;

            if (CurrentQuestionIndex < Questions.Count)
            {
                // Display the next question
                CurrentQuestion = Questions[CurrentQuestionIndex].Text;
            }
            else
            {
                // Quiz completed, navigate to the results page
                Shell.Current.GoToAsync(state: "//Results");
                FinalPoints.QuizActive = false;
                
                // Reset question index for future retakes
                CurrentQuestionIndex = 0;
                CurrentQuestion = Questions[CurrentQuestionIndex].Text;
            }
        }

        // Command method to view results
        [RelayCommand]
        public static void ViewResults()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Results");
        }

        // Command method to retake the quiz
        [RelayCommand]
        public static void RetakeQuiz()
        {
            // Reset the final points and quiz status
            FinalPoints.FinalDemocraticPoints = 0;
            FinalPoints.FinalRepublicanPoints = 0;
            FinalPoints.FinalLibertarianPoints = 0;
            FinalPoints.FinalGreenPoints = 0;
            FinalPoints.FinalOtherPoints = 0;

            FinalPoints.QuizActive = true;
        }
    }
}