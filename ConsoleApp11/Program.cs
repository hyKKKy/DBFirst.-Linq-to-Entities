using System.Reflection.Emit;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Academy2712Context db = new Academy2712Context())
            {
                var task1 = from teach in db.Teachers
                            from gr in db.Groups
                            select new
                            {
                                t_name = teach.Name,
                                gr_name = gr.Name
                            };
                foreach (var i in task1)
                {
                    Console.WriteLine(i.t_name + '-' + i.gr_name);
                }

                var task2 = from fac in db.Faculties
                            join dep in db.Departments on fac.Id equals dep.FacultyId
                            where dep.Financing > fac.Financing
                            select fac.Name;
                foreach (var i in task2.Distinct())
                {
                    Console.WriteLine(i);
                }

                var task3 = from gc in db.GroupsCurators
                            join cur in db.Curators on gc.CuratorId equals cur.Id
                            join gr in db.Groups on gc.GroupId equals gr.Id
                            select new
                            {
                                c_name = cur.Surname,
                                g_name = gr.Name
                            };
                foreach (var i in task3)
                {
                    Console.WriteLine(i.c_name + '-' + i.g_name);
                }

                var task4 = from teach in db.Teachers
                            join lec in db.Lectures on teach.Id equals lec.TeacherId
                            join gl in db.GroupsLectures on lec.Id equals gl.LectureId
                            join gr in db.Groups on gl.GroupId equals gr.Id
                            where gr.Name == "P30"
                            select teach.Name;
                foreach (var i in task4.Distinct())
                {
                    Console.WriteLine(i);
                }

                var task5 = from teach in db.Teachers
                            join lec in db.Lectures on teach.Id equals lec.TeacherId
                            join gl in db.GroupsLectures on lec.Id equals gl.LectureId
                            join gr in db.Groups on gl.GroupId equals gr.Id
                            join dep in db.Departments on gr.DepartamentId equals dep.Id
                            join fac in db.Faculties on dep.FacultyId equals fac.Id
                            select new
                            {
                                t_name = teach.Surname,
                                f_name = fac.Name
                            };
                foreach (var i in task5)
                {
                    Console.WriteLine(i.t_name + " - " + i.f_name);

                }

                var task6 = from dep in db.Departments
                            join gr in db.Groups on dep.Id equals gr.DepartamentId
                            select new
                            {
                                gr_name = gr.Name,
                                dep_name = dep.Name
                            };
                foreach (var i in task6)
                {
                    Console.WriteLine(i.gr_name + " - " + i.dep_name);
                }

                var task7 = from sub in db.Subjects
                            join lec in db.Lectures on sub.Id equals lec.SubjectId
                            join teach in db.Teachers on lec.TeacherId equals teach.Id
                            where teach.Name == "Emily" && teach.Surname == "Johnson"
                            select sub.Name;
                foreach (var i in task7.Distinct())
                {
                    Console.WriteLine(i);
                }

                var task8 = from dep in db.Departments
                            join gr in db.Groups on dep.Id equals gr.DepartamentId
                            join gl in db.GroupsLectures on gr.Id equals gl.GroupId
                            join lec in db.Lectures on gl.LectureId equals lec.Id
                            join sub in db.Subjects on lec.SubjectId equals sub.Id
                            where sub.Name == "Computer Science"
                            select dep.Name;
                foreach (var i in task8)
                {
                    Console.WriteLine(i);
                }

                var task9 = from gr in db.Groups
                            join dep in db.Departments on gr.DepartamentId equals dep.Id
                            join fac in db.Faculties on dep.FacultyId equals fac.Id
                            where fac.Name == "Faculty of Computer Science"
                            select gr.Name;
                foreach (var i in task9)
                {
                    Console.WriteLine(i);
                }

                var task10 = from gr in db.Groups
                             join dep in db.Departments on gr.DepartamentId equals dep.Id
                             join fac in db.Faculties on dep.FacultyId equals fac.Id
                             where gr.Year == 5
                             select new
                             {
                                 gr_name = gr.Name,
                                 fac_name = fac.Name
                             };
                foreach (var i in task10)
                {
                    Console.WriteLine(i.gr_name + " - " + i.fac_name);
                }

                var task11 = from teach in db.Teachers
                             join lec in db.Lectures on teach.Id equals lec.TeacherId
                             join sub in db.Subjects on lec.SubjectId equals sub.Id
                             join gl in db.GroupsLectures on lec.Id equals gl.LectureId
                             join gr in db.Groups on gl.GroupId equals gr.Id
                             where lec.LectureRoom == "LR14"
                             select new 
                             { 
                                t_name = teach.Name,
                                t_surname = teach.Surname,
                                s_name = sub.Name,
                                gr_name = gr.Name
                             };
                foreach(var i in task11)
                {
                    Console.WriteLine(i.t_name + i.t_surname + " - " + i.s_name + " - " + i.gr_name);
                }

            }
        }
    }
}
