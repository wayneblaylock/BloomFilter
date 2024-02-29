namespace tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorWorks()
    {
        bloomFilter test = new bloomFilter(30);
        Assert.That(test.PossibleFalsePositives, Is.EqualTo(0));
    }
    [Test]
    public void AddOneAndContainsWorks()
    {
        bloomFilter test = new bloomFilter(30);
        test.Add("dog");
        Assert.That(test.Contains("dog"), Is.EqualTo(true));
        Assert.That(test.Contains("dot"), Is.EqualTo(false));
    }
    [Test]
    public void AddThreeAndContainsWorks()
    {
        bloomFilter test = new bloomFilter(30);
        test.Add("dog");
        test.Add("cat");
        test.Add("mouse");
        Assert.That(test.Contains("dog"), Is.EqualTo(true));
        Assert.That(test.Contains("cat"), Is.EqualTo(true));
        Assert.That(test.Contains("mouse"), Is.EqualTo(true));
    }
    [Test]
    public void FalsePositivesCounterWorks()
    {
        bloomFilter test = new bloomFilter(3);
        test.Add("dog");
        test.Add("cat");
        test.Add("mouse");
        test.Add("dog");
        Assert.That(test.PossibleFalsePositives, Is.GreaterThan(0));
    }
}