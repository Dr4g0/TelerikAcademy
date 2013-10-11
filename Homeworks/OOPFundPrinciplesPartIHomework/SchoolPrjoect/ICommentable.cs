using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrjoect
{
    public interface ICommentable
    {
        List<string> AllComments { get; set; }
        void AddComment(string comment);
    }
}
