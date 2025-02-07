namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(Academy2712Context db = new Academy2712Context())
            {
                //var task1 = from teach in db.Teachers
                //            from gr in db.Groups
                //            select new
                //            {
                //                t_name = teach.Name,
                //                gr_name = gr.Name
                //            };
                //foreach(var i in task1)
                //{
                //    Console.WriteLine(i.t_name + '-' + i.gr_name);
                //}

                //var task2 = from fac in db.Faculties
                //            join dep in db.Departments on fac.Id equals dep.FacultyId
                //            where dep.Financing > fac.Financing
                //            select fac.Name;
                //foreach (var i in task2.Distinct())
                //{
                //    Console.WriteLine(i);
                //}

                var task3 = from gc in db.GroupsCurators
                            join cur in db.Curators on gc.CuratorId equals cur.Id
                            join gr in db.Groups on gc.GroupId equals gr.Id
                            select new
                            {
                                c_name = cur.Surname,
                                g_name = gr.Name
                            };
                foreach(var i in task3)
                {
                    Console.WriteLine(i.c_name + '-' + i.g_name);
                }

                var task4 = from teach in db.Teachers
                            join lec in db.Lectures on teach.Id equals lec.TeacherId
                            join gl in db.GroupsLectures on lec.Id equals gl.LectureId
                            join gr in db.Groups on gl.GroupId equals gr.Id
                            where gr.Name == "P30"
                            select teach.Name;
                foreach(var i in task4.Distinct())
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
