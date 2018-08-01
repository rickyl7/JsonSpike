using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonSpike
{
    [TestFixture]
    public class JsonTests
    {
        [Test]
        public void Basic_serialization()
        {
            var roster = new Roster();
            roster.Characters = new[] {
                new Character() {
                    Name = "Captain America",
                    Roles = new [] { Character.RoleEnum.Defense, Character.RoleEnum.Purge }
                }
            };

            string json = JsonConvert.SerializeObject(roster);

            Assert.That(json, Is.EqualTo("{\"Characters\":[{\"Name\":\"Captain America\",\"Roles\":[0,1]}]}"));
        }

        [Test]
        public void Basic_Deserialization()
        {
            var roster = JsonConvert.DeserializeObject<Roster>("{\"Characters\":[{\"Name\":\"Captain America\",\"Roles\":[0,1]}]}");

            Assert.That(roster, Is.Not.Null);
            Assert.That(roster.Characters.Count(), Is.EqualTo(1));

            Character character = roster.Characters.First();
            Assert.That(character.Name, Is.EqualTo("Captain America"));
            Assert.That(character.Roles.Count(), Is.EqualTo(2));
            Assert.That(character.Roles, Has.Member(Character.RoleEnum.Defense));
            Assert.That(character.Roles, Has.Member(Character.RoleEnum.Purge));
            Assert.That(character.Roles, Has.No.Member(Character.RoleEnum.AOE));
        }
    }
}
