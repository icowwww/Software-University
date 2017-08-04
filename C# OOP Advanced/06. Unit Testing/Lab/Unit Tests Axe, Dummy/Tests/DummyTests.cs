using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        var dummy = new Dummy(20, 10);

        dummy.TakeAttack(5);

        Assert.AreEqual(dummy.Health, 15);
    }

    [Test]
    public void AliveDummyCantGiveExp()
    {
        var dummy = new Dummy(20, 10);

        var ex = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        Assert.AreEqual(ex.Message, "Target is not dead.");
    }

    [Test]
    public void DeadDummyCanGiveExp()
    {
        var dummy = new Dummy(0, 10);

        Assert.AreEqual(dummy.GiveExperience(), 10);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        var dummy = new Dummy(10, 10);

        dummy.TakeAttack(5);

        Assert.AreEqual(dummy.Health, 5);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        var dummy = new Dummy(0, 10);

        var ex = Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));

        Assert.AreEqual(ex.Message, "Dummy is dead.");

    }
}