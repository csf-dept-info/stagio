using System.Collections.Generic;

namespace Stagio.Web.ViewModels.Coordinator
{
    public class StudentsList
    {
        public List<ViewModels.Student.Index> subscribedStudents { get; set; }

        public List<ViewModels.Student.Index> notSubscribedStudents { get; set; }
    }
}