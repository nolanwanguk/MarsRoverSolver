namespace MarsRover
{
    public class Tests
    {
        private Solver Solver;
        [SetUp]
        public void Setup()
        {
            Solver = new Solver();
        }

        [Test]
        public void Test1()
        {
            Assert.That(Solver.Run(5, 5, 1, 2, "N", new List<string> { "L", "M", "L", "M", "L", "M", "L", "M", "M" }),Is.EqualTo(new String[] { "1", "3", "N"}));
        }
        public void Test2()
        {
            Assert.That(Solver.Run(5, 5, 3, 3, "E", new List<string> { "M", "M", "R", "M", "M", "R", "M", "R", "R", "M" }), Is.EqualTo(new String[] { "5", "1", "E" }));
        }
    }
}