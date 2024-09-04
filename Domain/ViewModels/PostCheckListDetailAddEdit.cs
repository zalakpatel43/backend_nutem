using System;

namespace Domain.ViewModels
{
    public class PostCheckListDetailAddEdit
    {
        public long Id { get; set; }
        public long HeaderId { get; set; }
        public long QuestionId { get; set; }
        public int Answer { get; set; }
        public string Reason { get; set; }

        public string ReasonFormatted
        {
            get
            {
                return string.IsNullOrEmpty(Reason) ? "N/A" : Reason;
            }
        }
    }
}
