using CodeBlogFitness_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness_BL.Controller
{
    public class ExerciseController : BaseController
    {
        private readonly User currentUser;
        public List<Exercise> Exercises { get; set; }
        public List<Activity> Activities { get; set; }

        public ExerciseController(User currentUser)
        {
            this.currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime startTime, DateTime finishTime)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            Exercise exercise = null;

            if (act == null)
            {
                Activities.Add(activity);

                exercise = new Exercise(startTime, finishTime, activity, currentUser);
            }
            else
            {
               exercise = new Exercise(startTime, finishTime, act, currentUser);
            }
            Exercises.Add(exercise);
            Save();
        }

        private List<Activity> GetAllActivities()
        {
            return LoadData<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return LoadData<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            SaveData(Exercises);
            SaveData(Activities);
        }
    }
}
