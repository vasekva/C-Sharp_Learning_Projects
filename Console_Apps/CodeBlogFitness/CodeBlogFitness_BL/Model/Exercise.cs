using System;
using System.Runtime.Serialization;

namespace CodeBlogFitness_BL.Model
{
    [DataContract]
    public class Exercise
    {
        #region Свойства
        public int Id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime StartTime { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime FinishTime { get; set; }

        public int ActivityId { get; set; }

        [DataMember]
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }
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
