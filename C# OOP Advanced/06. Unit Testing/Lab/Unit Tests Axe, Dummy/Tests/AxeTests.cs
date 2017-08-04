using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        var axe = new Axe(10,10);
        var dummy = new Dummy(10,10);

        axe.Attack(dummy);

        Assert.AreEqual(9, axe.DurabilityPoints);
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        var axe = new Axe(1,1);
        var dummy = new Dummy(10,10);

        axe.Attack(dummy);

        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}