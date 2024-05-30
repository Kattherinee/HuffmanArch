using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Справочник_студента.Form1;

namespace Справочник_студента
{
  
    public partial class Form1 : Form
    {
        public interface IEntity
        {
            string GetDetails();
        }
        public abstract class AcademicEntity : IEntity
        {
            public string Name { get; set; }

            public abstract string GetDetails();
        }
        public class Discipline : AcademicEntity
        {
            public int LectureHours { get; set; }
            public int LabHours { get; set; }
            public int PracticalHours { get; set; }
            public bool HasExam { get; set; }
            public bool HasCredit { get; set; }
            public bool HasCourseWork { get; set; }
            public int Semester { get; set; }
            public char Block { get; set; }

            public override string GetDetails()
            {
                return $"{Name} - Lectures: {LectureHours}, Labs: {LabHours}, Practicals: {PracticalHours}, Exam: {HasExam}, Credit: {HasCredit}, Course Work: {HasCourseWork}, Semester: {Semester}, Block: {Block}";
            }

            public override string ToString()
            {
                return GetDetails();
            }
        }
        public class StudyPlan
        {
            public string Specialty { get; set; }
            public int EnrollmentYear { get; set; }
            public string StudyForm { get; set; } // Daytime, Evening, Correspondence
            public string Qualification { get; set; } // Bachelor, Specialist, Master
            public List<Discipline> Disciplines { get; set; } = new List<Discipline>();

            public List<Discipline> FilterByDisciplineName(string name)
            {
                return Disciplines.FindAll(d => d.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase));
            }

            public List<Discipline> FilterBySemester(int semester)
            {
                return Disciplines.FindAll(d => d.Semester == semester);
            }

            public List<Discipline> FilterByCourseWorkPresence(bool hasCourseWork)
            {
                return Disciplines.FindAll(d => d.HasCourseWork == hasCourseWork);
            }
        }
        public Form1()
        {
            InitializeComponent();
            InitializeStudyPlans();
        }
        private void InitializeStudyPlans()
        {
            // Инициализация учебных планов
            studyPlans = new List<StudyPlan>
            {
                new StudyPlan
                {
                    Specialty = "Computer Science",
                    EnrollmentYear = 2021,
                    StudyForm = "Daytime",
                    Qualification = "Bachelor",
                    Disciplines = new List<Discipline>
                    {
                        new Discipline
                        {
                            Name = "Programming",
                            LectureHours = 40,
                            LabHours = 20,
                            PracticalHours = 30,
                            HasExam = true,
                            HasCredit = false,
                            HasCourseWork = true,
                            Semester = 1,
                            Block = 'A'
                        },
                        new Discipline
                        {
                            Name = "Mathematics",
                            LectureHours = 60,
                            LabHours = 0,
                            PracticalHours = 40,
                            HasExam = true,
                            HasCredit = false,
                            HasCourseWork = false,
                            Semester = 1,
                            Block = 'B'
                        }
                    }
                }
            };
        }
        private void DisplayStudyPlans()
        {
            listBoxStudyPlans.Items.Clear();
            foreach (var plan in studyPlans)
            {
                foreach (var discipline in plan.Disciplines)
                {
                    listBoxStudyPlans.Items.Add(discipline);
                }
            }
        }
    }
}
