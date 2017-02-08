using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManage
{
    class Information
    {
        public string[] DepartmentName = { "選んでください", "理学第一部", "工学第一部", "薬学部", "理工学部", "基礎工学部", "経営学部", "理学第二部", "工学第二部" };
        public string[] Science1SubjectName = { "選んでください", "数学科", "物理学科", "化学科", "数理情報科学科", "応用物理学科", "応用化学科" };
        public string[] Faculty1SubjectName = { "選んでください", "建築学科", "工業化学科", "電気工学科", "経営工学科", "機械工学科", "情報工学科" };
        public string[] MedicineSubjectName = { "選んでください", "薬学科", "生命創薬科学科" };
        public string[] ScienceTechnologySubjectName = { "選んでください", "数学科", "物理学科", "情報科学科", "応用生物科学科", "建築学科", "工業化学科", "電気電子情報工学科", "経営工学科", "機械工学科", "土木工学科" };
        public string[] FoundationFacultySubjectName = { "選んでください", "電子応用工学科", "材料工学科", "生物工学科" };
        public string[] ManagementSubjectName = { "選んでください", "ビジネスエコノミクス学科", "経営学科" };
        public string[] Science2SubjectName = { "選んでください", "数学科", "物理学科", "化学科" };
        public string[] Faculty2SubjectName = { "選んでください", "建築学科", "電気工学科", "経営工学科" };
        public string[] ChooseName = { "選んでください" };
        public string[] MessageSubjectName = { "まず、学部名を選んでください"};

        public string[] StudyName = { "選んでください", "理学研究科", "総合科学研究科", "科学教育研究科", "工学研究科", "薬学研究科", "理工学研究科", "基礎工学研究科", "経営学研究科", "生命科学研究科", "イノベーション研究科", "国際火災科学研究科" };
        public string[] ScienceMajorName = { "選んでください", "数学専攻", "物理学専攻", "数理情報科学専攻", "応用物理学専攻" };
        public string[] ChemicalMajorName = { "選んでください", "総合化学専攻" };
        public string[] EducationMajorName = { "選んでください", "科学教育専攻" };
        public string[] FacultMajorName = { "選んでください", "建築学専攻", "電気工学専攻", "経営工学専攻", "機械工学専攻" };
        public string[] MedicineMajorName = { "選んでください", "薬科学専攻", "薬学専攻" };
        public string[] ScienceTechnologyMajorName = { "選んでください", "数学専攻", "物理学専攻", "情報科学専攻", "応用生物科学専攻", "建築学専攻", "工業化学専攻", "電気工学専攻", "経営工学専攻", "機械工学専攻", "土木工学専攻" };
        public string[] FoundationFacultyMajorName = { "選んでください", "電子応用工学専攻", "材料工学専攻", "生物工学専攻" };
        public string[] ManagementMajorName = { "選んでください", "経営学専攻" };
        public string[] BiologicalMajorName = { "選んでください", "生命科学専攻" };
        public string[] InnovationMajorName = { "選んでください", "イノベーション専攻" };
        public string[] GlobalFireMajorName = { "選んでください", "火災科学専攻" };
        public string[] MessageMajorName = { "まず、研究科名を選んでください" };

        public string[] SelectSubject(int index)
        {
            switch (index)
            {
                case 0:
                    return MessageSubjectName;
                case 1:
                    return Science1SubjectName;
                case 2:
                    return Faculty1SubjectName;
                case 3:
                    return MedicineSubjectName;
                case 4:
                    return ScienceTechnologySubjectName;
                case 5:
                    return FoundationFacultySubjectName;
                case 6:
                    return ManagementSubjectName;
                case 7:
                    return Science2SubjectName;
                case 8:
                    return Faculty2SubjectName;               
                default:
                    return ChooseName;
            }
        }

        public string[] SelectMajor(int index)
        {
            switch (index)
            {
                case 0:
                    return MessageMajorName;
                case 1:
                    return ScienceMajorName;
                case 2:
                    return ChemicalMajorName;
                case 3:
                    return EducationMajorName;
                case 4:
                    return FacultMajorName;
                case 5:
                    return MedicineMajorName;
                case 6:
                    return ScienceTechnologyMajorName;
                case 7:
                    return FoundationFacultyMajorName;
                case 8:
                    return ManagementMajorName;
                case 9:
                    return BiologicalMajorName;
                case 10:
                    return InnovationMajorName;
                case 11:
                    return GlobalFireMajorName;
                default:
                    return ChooseName;
            }
        }

    }
}
