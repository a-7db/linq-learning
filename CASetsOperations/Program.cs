
using MeetingData;

namespace CASetsOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunDistinct();
            //RunExcept();
            //RunIntersect();
            RunUnion();

            Console.ReadKey();
        }

        private static void RunDistinct()
        {
            var meeting01 = Repository.Meeting1.Participants;
            var meeting02 = Repository.Meeting2.Participants;

            // If there are Equals & getHashCode overload will apply Distinct()
            var participantsm1m2 = meeting01.Concat(meeting02).Distinct();

            //participantsm1m2.Print("========== Who Sharing meeting 1 & 2");

            // If Not Use Equals Overload  &  give it the key to compare it --> x.EmployeeNo
            var distinctBy = meeting01.Concat(meeting02).DistinctBy(x => x.EmployeeNo);


            distinctBy.Print("========== Who Sharing meeting 1 & 2 & DistinctBy()");
        }

        private static void RunExcept()
        {
            // IDEA: Take any employee not on second meeting
            var meeting01 = Repository.Meeting1.Participants;
            var meeting02 = Repository.Meeting2.Participants;

            var exception01 = meeting01.Except(meeting02);
            // Same Previous Idea
            var exception02 = meeting01.ExceptBy(meeting02.Select(x => x.EmployeeNo), x => x.EmployeeNo);

            exception02.Print("meeting01.Except(meeting02)");
        }
        private static void RunIntersect()
        {
            // IDEA: Take only who is shared in both meetings
            var meeting01 = Repository.Meeting1.Participants;
            var meeting02 = Repository.Meeting2.Participants;

            var intersect01 = meeting01.Intersect(meeting02);
            var intersect02 = meeting01.IntersectBy(meeting02.Select(x => x.EmployeeNo), x => x.EmployeeNo);

            intersect02.Print("meeting01.Intersect(meeting02)");
        }

        private static void RunUnion()
        {
            // Take all employees without dublicating
            var meeting01 = Repository.Meeting1.Participants;
            var meeting02 = Repository.Meeting2.Participants;

            var union01 = meeting01.Union(meeting02);
            var union02 = meeting01.UnionBy(meeting02, x => x.EmployeeNo);

            union02.Print("meeting01.UnionBy(meeting02)");
        }
    }
}
