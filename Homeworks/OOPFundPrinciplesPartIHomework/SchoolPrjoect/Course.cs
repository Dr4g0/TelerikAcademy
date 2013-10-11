using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    class Course : ICommentable
    {
        private List<string> allComments = new List<string>();
        public string CourseName { get; set; }
        public int NumberLectures { get; set; }
        public int NumberExercises { get; set; }

        public List<string> AllComments
        {
            get { return this.allComments; }
            set { this.allComments = value; }
        }
        
        public Course(string name,int lectures,int exercises)
        {
            this.CourseName = name;
            this.NumberLectures = lectures;
            this.NumberExercises = exercises;
        }

        public void AddComment(string comment)
        {
            AllComments.Add(comment);
        }
    }
}
