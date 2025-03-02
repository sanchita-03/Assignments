namespace Task_2
{
    class EventRegistration
    {
        Dictionary<string, HashSet<int>> workshopRegistration = new Dictionary<string, HashSet<int>>();
        public void Registration(string workshopname,int studentId)
        {
            if (!workshopRegistration.ContainsKey(workshopname))
            {
                workshopRegistration[workshopname] = new HashSet<int>();
            }
            if (workshopRegistration[workshopname].Add(studentId))
            {
                Console.WriteLine("added successfuly");
            }
            else
            {
                Console.WriteLine("you can register only once");
            }
        }
        public void PrintAllDetails()
        {
            Console.WriteLine("*****************************************");
            foreach (var workshop in workshopRegistration)
            {
                Console.Write(workshop.Key +" :\n{");
                foreach (var id in workshop.Value)
                {
                    Console.Write(id +" ");
                }
                Console.Write("}\n");
            }
            Console.WriteLine("*****************************************");
        }
    }
}
