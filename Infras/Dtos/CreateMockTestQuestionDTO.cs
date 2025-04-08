using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infras.Dtos
{
     public  class CreateMockTestQuestionDTO
      {

        public Int64 MockTestCategoryID { get; set; }
        public String MockTestCategoryName { get; set; }
        public Int64 MockTestSubjectID { get; set; }
        public String SubjectTitle { get; set; }
        public Int64 MockTestQuestionID { get; set; }
        public String Questions { get; set; }
        public String Option1 { get; set; }
        public bool iscorrect1 {  get; set; }
        public String Option2 { get; set; }
        public bool iscorrect2 { get; set; }
        public String Option3 { get; set; }
        public bool iscorrect3 { get; set; }

        public String Option4 { get; set; }
        public bool iscorrect4 { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
