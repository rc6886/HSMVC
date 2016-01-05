using System;
using System.Linq;
using HSMVC.DataAccess;
using HSMVC.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace HSMVC.Tests.Conference
{
    [TestFixture]
    public class ConferenceTests
    {
        private IConferenceRepository _repository;

        [SetUp]
        public void InitializeTestFixture()
        {
            _repository = new ConferenceRepository(NHibernateHelper.OpenSession());
        }

        [Test]
        public void ShouldGetAllConferences()
        {
            var conferences = _repository.GetAll().ToArray();

            conferences.Length.ShouldBe(3);

            conferences[0].Id.ShouldBe(Guid.Parse("0E3E638E-DA0B-47DF-B2FC-07F6CC7618DE"));
            conferences[1].Id.ShouldBe(Guid.Parse("C2AD9DAC-B936-442E-B46D-A73C0B69C147"));
            conferences[2].Id.ShouldBe(Guid.Parse("F41C8CFC-A6E3-4309-8023-D1425D294468"));
        }      
    }
}