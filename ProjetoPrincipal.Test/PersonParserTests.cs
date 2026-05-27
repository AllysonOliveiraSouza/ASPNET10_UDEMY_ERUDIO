using FluentAssertions;
using ProjetoPrincipal.Data.Converter.Implementation;
using ProjetoPrincipal.Data.DTO.V2;
using ProjetoPrincipal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoPrincipal.Tests
{
    public class PersonParserTests
    {
        private readonly PersonParserV2 _personParser;
        public PersonParserTests()
        {
            _personParser = new PersonParserV2(); 
        }

        [Fact]
        public void Parse_ShouldConvertPersonDTOtoPerson()
        {
            var dto = new PersonDTO()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "da Silva",
                Address = "Rua Teste",
                Gender = "Male",
                Birthday = DateTime.Now
            };

            var expectedPerson = new Person()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "da Silva",
                Address = "Rua Teste",
                Gender = "Male"
            };

            var person = _personParser.Parse(dto);

            person.Should().NotBeNull();

            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_ShouldConvertPersontoPersonDTO()
        {
            var entity = new Person()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "da Silva",
                Address = "Rua Teste",
                Gender = "Male"
            };

            var expectedPerson = new PersonDTO()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "da Silva",
                Address = "Rua Teste",
                Gender = "Male",
                Birthday = DateTime.Now
            };

            var dto = _personParser.Parse(entity);

            dto.Should().NotBeNull();

            dto.Id.Should().Be(expectedPerson.Id);
            dto.FirstName.Should().Be(expectedPerson.FirstName);
            dto.LastName.Should().Be(expectedPerson.LastName);
            dto.Gender.Should().Be(expectedPerson.Gender);
            dto.Should()
            .BeEquivalentTo(expectedPerson,
            options=> options.Excluding(dto => dto.Birthday));
            dto.Birthday.Should().NotBeNull();
        }

        [Fact]

        public void Parse_NullPersonDTOShouldReturnNull()
        {
            PersonDTO dto = null;
            var person = _personParser.Parse(dto);
            person.Should().BeNull();
        }

        [Fact]

        public void Parse_NullPersonShouldReturnNull()
        {
            Person entity = null;
            var person = _personParser.Parse(entity);
            person.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            // Arrange
            var dtoList = new List<PersonDTO>()
            {
                new(){
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Any",
                Gender = "Male",
                Birthday = new DateTime(1869,10,2)                
                },
                new(){
                    Id = 2,
                    FirstName = "Indira",
                    LastName = "Gandhi",
                    Address = "Any",
                    Gender = "Female",
                    Birthday = new DateTime(1917,11,19)
                }
            };

            // Act

            var personList = _personParser.ParseList(dtoList);

            // Assert

            personList.Should().NotBeNull();
            personList.Should().HaveCount(2);

            personList[0].Should().BeEquivalentTo(new Person {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Any",
                Gender = "Male"
            });

            personList[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Indira",
                LastName = "Gandhi",
                Address = "Any",
                Gender = "Female"
            });

            personList[0].FirstName.Should().Be("Mahatma");
            personList[1].FirstName.Should().Be("Indira");
            personList[1].LastName.Should().Be("Gandhi");
        }

        [Fact]
        public void Parse_NullListPersonDTOShouldReturnNull()
        {
            List<PersonDTO> list = null;
            var listperson = _personParser.ParseList(list);
            listperson.Should().BeNull();
        }

        [Fact]
        public void ParsePersonListToPersonDTOList() {

            List<Person> listPerson = [new() { Id = 1, FirstName="Allyson"}, new() { Id = 2, FirstName="Amanda"}];
            var listDto = _personParser.ParseList(listPerson);

            listDto.Should().NotBeNull();
            listDto.Should().HaveCount(2);
        }
    }
}
