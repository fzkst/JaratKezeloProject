using NUnit.Framework;
using JaratKezeloProject;
using System;


namespace TestJaratKezeloProject
{
    public class Tests
    {
        Jarat jarat;


        [SetUp]
        public void Setup()
        {
            jarat = new Jarat("A112", "Auckland Airport", "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
        }


        [Test]
        public void UjJaratJaratszamUres()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("", "Auckland Airport", "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratJaratszamNull()
        {
            Assert.Throws<ArgumentNullException>(() => jarat.UjJarat(null, "Auckland Airport", "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratLetezoJaratszammal()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A111", "Auckland Airport", "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratHonnanRepterUres()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A116", "", "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratHonnanRepterNull()
        {
            Assert.Throws<ArgumentNullException>(() => jarat.UjJarat("A116", null, "Edinburgh Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratHovaRepterUres()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A116", "Edinburgh Airport", "", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratHovaRepterNull()
        {
            Assert.Throws<ArgumentNullException>(() => jarat.UjJarat("A116", "Edinburgh Airport", null, new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratNemLetezoRepterrel()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A116", "Edinburgh Airport", "Rio Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0));
        }

        [Test]
        public void UjJaratKesessel()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 10));
        }

        [Test]
        public void UjJaratNegativKesessel()
        {
            Assert.Throws<ArgumentException>(() => jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), -10));
        }

        [Test]
        public void KesesUresJaratszammal()
        {
            Assert.Throws<ArgumentException>(() => jarat.Keses("", 10));
        }

        [Test]
        public void KesesJaratszamNull()
        {
            Assert.Throws<ArgumentNullException>(() => jarat.Keses(null, 10));
        }

        [Test]
        public void KesesNemletezoJaratszammal()
        { 
            Assert.Throws<ArgumentException>(() => jarat.Keses("A117", 10));
        }

        [Test]
        public void KesesNulla()
        {
            Assert.DoesNotThrow(() => jarat.Keses("A112", 0));
        }

        [Test]
        public void KesesPluszTizzel()
        {
            Assert.DoesNotThrow(() => jarat.Keses("A112", 10));
        }

        [Test]
        public void KesesAtmegyNegativba()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            jarat.UjJarat("A117", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            jarat.UjJarat("A118", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentException>(() => jarat.Keses("A117", -1));
        }

        [Test]
        public void MikorindulJaratszamUres()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentException>(() => jarat.MikorIndul(""));
        }

        [Test]
        public void MikorindulJaratszamNull()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentNullException>(() => jarat.MikorIndul(null));
        }

        [Test]
        public void MikorindulNemletezoJaratszammal()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentException>(() => jarat.MikorIndul("A120"));
        }

        [Test]
        public void MikorindulHelyesErtekkel()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.AreEqual(new System.DateTime(2022, 05, 12, 15, 30, 00), jarat.MikorIndul("A116"));            
        }

        [Test]
        public void JaratokRepuloterrolRepterUres()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentException>(() => jarat.jaratokRepuloterrol(""));
        }

        [Test]
        public void JaratokRepuloterrolRepterNull()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<ArgumentNullException>(() => jarat.jaratokRepuloterrol(null));
        }

        [Test]
        public void JaratokRepuloterrolNemLetezik()
        {
            jarat.UjJarat("A116", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.Throws<Exception>(() => jarat.jaratokRepuloterrol("Rio Airport"));
        }

        [Test]
        public void JaratokRepuloterrolLetezoRepterrel()
        {                
            jarat.UjJarat("A118", "Edinburgh Airport", "Auckland Airport", new System.DateTime(2022, 05, 12, 15, 30, 00), 0);
            Assert.AreEqual("A118", jarat.jaratokRepuloterrol("Edinburgh Airport"));
        }

    }
}