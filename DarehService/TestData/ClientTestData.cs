using System;
using System.Collections.Generic;
using DarehService.API.Models;

namespace DarehService.API.TestData
{
  public class ClientTestData
  {
    private static readonly Address Addres1 = new Address
    {
      StreetName = "Rafała Wojaczka",
      StreetNumber = "3",
      LocalNumber = "12",
      Community = "wrocławska",
      County = "wrocławski",
      City = "Wrocław",
      Province = "dolnośląskie",
      Country = "Polska",
      PostalCode = "50-169"
    };

    private static readonly Address Addres2 = new Address
    {
      StreetName = "Górna",
      StreetNumber = "38",
      LocalNumber = "5",
      Community = "zdzieszowice",
      County = "krapkowicki",
      City = "Zdzieszowice",
      Province = "opolskie",
      Country = "Polska",
      PostalCode = "47-330"
    };

    public static List<Client> Clients = new List<Client>
    {
      new Client
      {
        Id = new Guid("9275DCE8-6E42-49B7-A5B1-9C7E7A204665").ToString(),
        FirstName = "Rafał",
        Surname = "Nowak",
        CorrespondenceAddress = Addres2,
        RegisteredAddress =  Addres2,
        Email = "koziu92@gmail.com",
        RegisterDate = DateTime.Now,
        LastLogOnDate = DateTime.Now,
        Phone = "555666999"
      },
       new Client
      {
        Id = new Guid("05DD1051-96AE-4403-A50F-A090698A5F7D").ToString(),
        FirstName = "Mateusz",
        Surname = "Kozak",
        CorrespondenceAddress = Addres1,
        RegisteredAddress =  Addres1,
        Email = "koziu92@live.com",
        RegisterDate = DateTime.Now,
        LastLogOnDate = DateTime.Now,
        Phone = "535120399"
      }
    };


  }
}