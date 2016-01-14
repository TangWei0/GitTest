using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManage
{
    class Information
    {
        public string[] DepartmentName = {"理学第一部","工学第一部","薬学部","理工学部","基礎工学部","経営学部","理学第二部","工学第二部" };
        public string[] ScienceSubjectName = { "数学科", "物理学科", "化学科", "数理情報科学科", "応用物理学科", "応用化学科" };
        public string[] FacultySubjectName = { "建築学科", "工業化学科", "電気工学科", "経営工学科", "機械工学科", "情報工学科" };


        public string[] SelectSubject(string departmentName)
        {
            switch (departmentName)
            {
                case "理学第一部":
                    return ScienceSubjectName;
                case "工学第一部":
                    return FacultySubjectName;
                default:
                    break;
            }
            return FacultySubjectName;
        }

    }
}
