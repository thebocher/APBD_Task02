using APBD_Task02;
using JetBrains.Annotations;
using Xunit;

namespace PersonalComputerTest;

[TestSubject(typeof(PersonalComputer))]
public class PersonalComputerTest
{

    [Fact]
    public void TestEmptySystemException()
    {
        PersonalComputer personalComputer = new PersonalComputer();
        Assert.Throws<EmptySystemException>(() => personalComputer.TurnOn());
    }


    [Fact]
    public void TestNoEmptySystemException()
    {
        PersonalComputer personalComputer = new PersonalComputer();
        personalComputer.OperationalSystem = "some os";
    }
}