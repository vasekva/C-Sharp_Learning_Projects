using System;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    [DataContract]
    public class Exercise
    {
        #region Свойства
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime StartTime { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public Activity Activity { get; set; }

        [DataMember]
        public User User { get; set; }
        #endregion

        public Exercise(DateTime startTime, DateTime finishTIme, Activity activity, User user)
        {
            StartTime = startTime;
            FinishTime = finishTIme;
            Activity = activity;
            User = user;
        }
    }
}
